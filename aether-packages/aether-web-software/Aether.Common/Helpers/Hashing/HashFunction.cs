using Aether.Common.Helpers.Hashing.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aether.Common.Helpers.Hashing
{
    /// <summary>
    /// Class that represents a 32 bit hashing function.
    /// </summary>
    [DebuggerStepThrough]
    public sealed class HashFunction : HashFunctionBase
    {
        private HashFunctionBase _hashFunction;

        /// <summary>
        /// Creates a new hash function that uses the specified <see cref="Aether.Common.Helpers.Hashing.HashFunctionName"/> hash
        /// </summary>
        /// <param name="hashAlgorithm">The name of the hash function to use</param>
        public HashFunction(HashFunctionName hashAlgorithm)
        {
            _hashFunction = hashAlgorithm switch
            {
                HashFunctionName.FNV1A => new FNV1AHashFunction(),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Computes the hash value for the sequence using the specified hash algorithm
        /// </summary>
        /// <param name="data">The sequence</param>
        /// <returns>The computed hash</returns>
        public override uint Compute(IEnumerable<object?> data) =>
            _hashFunction.Compute(data);
    }
}
