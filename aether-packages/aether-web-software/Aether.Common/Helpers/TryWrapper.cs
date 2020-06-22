using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Common.Helpers
{
    /// <summary>
    /// Class for wrapping exception throwing methods to the try pattern
    /// </summary>
    public static class TryWrapper
    {

        /// <summary>
        /// Wraps a method that possibly throws an exception to the try pattern
        /// </summary>
        /// <typeparam name="T">The return value</typeparam>
        /// <param name="predicate">The returning function</param>
        /// <param name="value">The resulting value</param>
        /// <returns>True if method didn't throw exception; Otherwise false</returns>
        public static bool Try<T>(Func<T> predicate, [AllowNull] out T value)
        {
            value = default;
            try {
                value = predicate();
            }
            catch {
                return false;
            }
            return true;
        }

    }
}
