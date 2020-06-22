using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Common.Helpers.Hashing.Concrete
{
    /// <summary>
    /// Class that represents that FNV1A hashing function
    /// </summary>
    public sealed class FNV1AHashFunction : HashFunctionBase
    {
        // For details on constants see https://en.wikipedia.org/wiki/Fowler%E2%80%93Noll%E2%80%93Vo_hash_function
        private const uint _FNV_OFFSET_BASE = 0x811c9dc5;
        private const uint _FNV_PRIME = 0x01000193;

        /// <summary>
        /// Computes a hash for the sequence using the FNV1A algorithm
        /// </summary>
        /// <param name="sequence">The sequence</param>
        /// <returns>The computed hash</returns>
        public override uint Compute(IEnumerable<object?> sequence)
        {
            uint hash = _FNV_OFFSET_BASE;
            foreach (var elem in sequence)
            {
                if (elem is { })
                    hash = (uint)(hash ^ elem.GetHashCode());
                hash *= _FNV_PRIME;
            }
            return hash;
        }
    }
}
