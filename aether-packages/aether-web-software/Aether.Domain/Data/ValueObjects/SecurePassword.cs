using Aether.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Aether.Domain.Data.ValueObjects
{
    /// <summary>
    /// Represents a plain text password that follows certain validation rules.
    /// The password needs to be at least 8 characters long and contain one character and one number.
    /// </summary>
    [DebuggerStepThrough]
    internal sealed class SecurePassword : ValueObjectBase
    {
        // Regex that checks for one character, one number and a minimum length of 8 characters
        private static readonly Regex _PASSWORD_FORMAT = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", RegexOptions.Compiled);

        private string _password;
        private Lazy<bool> _isValid;

        /// <summary>
        /// Creates a new secure password
        /// </summary>
        /// <param name="password">The plain text password</param>
        public SecurePassword(string password)
        {
            _password = password;
            _isValid = new Lazy<bool>(ValidateInternal);
        }

        /// <summary>
        /// Checks wether the password matches the specific validation rules
        /// </summary>
        /// <returns>True if it matches the rules, otherwise false</returns>
        public bool IsValid() => _isValid.Value;

        private bool ValidateInternal() =>
            _PASSWORD_FORMAT.IsMatch(_password);

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return _password;
        }
    }
}
