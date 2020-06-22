using Aether.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Aether.Domain.Data.ValueObjects
{
    /// <summary>
    /// A key that is generated randomly.
    /// </summary>
    [DebuggerStepThrough]
    public sealed class RandomKey : ValueObjectBase
    {
        private const int _DEFAULT_KEY_LENGTH = 32;

        private Lazy<byte[]> _value;

        private RandomKey(Func<byte[]> thunk)
        {
            _value = new Lazy<byte[]>(thunk);
        }

        /// <summary>
        /// Generates a new random key
        /// </summary>
        /// <returns>The random key</returns>
        public static RandomKey GenerateKey()
        {
            Func<byte[]> thunk = () => GenerateKeyInternal(_DEFAULT_KEY_LENGTH);
            return new RandomKey(thunk);
        }

        /// <summary>
        /// Generates a new random key
        /// </summary>
        /// <param name="length">The length of the key</param>
        /// <returns>The random key</returns>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="length"/> is less than 0</exception>
        public static RandomKey GenerateKey(int length)
        {
            if (length < 0) 
                throw new ArgumentException("Cannot generate a key with a negative length", nameof(length));
            Func<byte[]> thunk = () => GenerateKeyInternal(length);
            return new RandomKey(thunk);
        }

        private static byte[] GenerateKeyInternal(int length)
        {
            using var rngProvider = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rngProvider.GetNonZeroBytes(bytes);
            return bytes;
        }

        /// <summary>
        /// Returns the generated key data
        /// </summary>
        /// <returns>The generated key data</returns>
        public byte[] GetValue() =>
            _value.Value;

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return GetValue();
        }

    }
}
