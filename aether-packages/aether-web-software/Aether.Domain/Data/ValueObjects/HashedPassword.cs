using Aether.Domain.Common;
using Aether.Domain.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Aether.Domain.Data.ValueObjects
{
    /// <summary>
    /// Represents a hashed password. 
    /// </summary>
    internal sealed class HashedPassword : ValueObjectBase
    {
        private const int _NUMBER_OF_ITERATIONS = 10_000;
        private const int _HASH_SIZE = 20;
        private const int _KEY_SIZE = 32;

        private string _password;
        private byte[] _salt;
        private Lazy<string> _value;

        /// <summary>
        /// Creates a new instance given a plain text password. The password is not being validated
        /// </summary>
        /// <param name="plainTextPassword">The plain text password</param>
        /// <exception cref="System.ArgumentException">Throws when <paramref name="plainTextPassword"/> is empty</exception>
        public HashedPassword(string plainTextPassword, byte[] salt)
        {
            if (string.IsNullOrEmpty(plainTextPassword)) 
                throw new ArgumentException("A password cannot be an empty string", nameof(plainTextPassword));
            _password = plainTextPassword;
            _salt = salt;
            _value = new Lazy<string>(HashInternal);
        }

        /// <summary>
        /// Extracts the salt from an already hashed password
        /// </summary>
        /// <param name="hashedPassword">The hashed password</param>
        /// <returns>The salt data</returns>
        /// <exception cref="ArgumentException">Throws when <paramref name="hashedPassword"/> has an invalid format</exception>
        public static byte[] ExtractSalt(string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            if (hashBytes.Length < _HASH_SIZE) 
                throw new ArgumentException("Invalid password hash", nameof(hashedPassword));
            byte[] salt = new byte[hashBytes.Length - _HASH_SIZE];
            Array.Copy(hashBytes, salt, salt.Length);
            return salt;
        }

        /// <summary>
        /// Hashes the password using a newly created password salt. Multiple calls to this method will return the same value.
        /// </summary>
        /// <returns>The hashed password</returns>
        public string Hash() => _value.Value;

        private string HashInternal()
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(_password, _salt, _NUMBER_OF_ITERATIONS, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(_HASH_SIZE);
            byte[] hashBytes = new byte[hash.Length + _salt.Length];
            Array.Copy(_salt, hashBytes, _salt.Length);
            Array.Copy(hash, 0, hashBytes, _salt.Length, hash.Length);
            return Convert.ToBase64String(hashBytes);
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return _value.Value;
        }
    }
}
