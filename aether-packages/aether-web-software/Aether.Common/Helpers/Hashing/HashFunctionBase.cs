using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Common.Helpers.Hashing
{
    /// <summary>
    /// Base class for hash functions
    /// </summary>
    public abstract class HashFunctionBase
    {
        /// <summary>
        /// Computes the hash for the given sequence
        /// </summary>
        /// <param name="sequence">The sequence</param>
        /// <returns>The resulting hash</returns>
        public abstract uint Compute(IEnumerable<object?> sequence);
    }
}
