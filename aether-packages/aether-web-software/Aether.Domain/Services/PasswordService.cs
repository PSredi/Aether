using Aether.Domain.Core.Exceptions;
using Aether.Domain.Data.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Domain.Services
{
    /// <summary>
    /// A factory that creates password hashes
    /// </summary>
    internal static class PasswordService
    {

        /// <summary>
        /// Generates a hashed password from a plain text password
        /// </summary>
        /// <param name="plainTextPassword">The plain text password</param>
        /// <returns>The hashed password</returns>
        /// <exception cref="Aether.Domain.Core.Exceptions.InvalidPasswordException">Throws an exception when the password is not secure enough or contains invalid characters</exception>
        public static string CreateFrom(string plainTextPassword)
        {
            var password = new SecurePassword(plainTextPassword);
            if (!password.IsValid()) throw new InvalidPasswordException();
            var randomKey = RandomKey.GenerateKey();
            var keyData = randomKey.GetValue();
            var hashedPassword = new HashedPassword(plainTextPassword, keyData);
            return hashedPassword.Hash();
        }

        /// <summary>
        /// Checks if a plain text password is can be hashed to a certain hashed password
        /// </summary>
        /// <param name="hashedPassword">The hashed password</param>
        /// <param name="plainTextPassword">The plain text password</param>
        /// <returns>True if <paramref name="plainTextPassword"/> can be hashed to <paramref name="hashedPassword"/></returns>
        public static bool AreEqual(string hashedPassword, string plainTextPassword)
        {
            var salt = HashedPassword.ExtractSalt(hashedPassword);
            var plainTextAsHashed = new HashedPassword(plainTextPassword, salt);
            return plainTextAsHashed.Hash() == hashedPassword;
        }

    }
}
