using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Common.Core
{
    /// <summary>
    /// A class that can be used to protect code from processing invalid parameters
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Checks if the string is null or empty
        /// </summary>
        /// <param name="param">The parameter</param>
        /// <param name="paramName">The parameters name</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="param"/> is null</exception>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="param"/> is empty</exception>
        public static void NotNullOrEmpty(string param, string paramName)
        {
            if (param is null) throw new ArgumentNullException(nameof(paramName));
            if (string.IsNullOrEmpty(param)) throw new ArgumentException("Empty string", nameof(paramName));
        }
    }
}
