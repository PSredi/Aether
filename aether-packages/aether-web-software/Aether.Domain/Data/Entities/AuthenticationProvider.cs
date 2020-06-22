using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Domain.Data.Entities
{
    /// <summary>
    /// Represents an AuthenticationProvider entity. AuthenticationProviders are used for 3rd party authentication / social logins
    /// </summary>
    public class AuthenticationProvider
    {
        /// <summary>
        /// The providers ID
        /// </summary>
        public int AuthenticationProviderID { get; set; }

        /// <summary>
        /// The providers authentication key
        /// </summary>
        [DisallowNull]
        public string AuthenticationKey { get; set; }

        /// <summary>
        /// The provider type
        /// </summary>
        [DisallowNull]
        public string ProviderType { get; set; }

        /// <summary>
        /// The user that corresponds to this social login authentication entry
        /// </summary>
        public int UserID { get; set; }

        internal AuthenticationProvider(string authenticationKey, string providerType, int userID)
        {
            AuthenticationKey = authenticationKey;
            ProviderType = providerType;
            UserID = userID;
        }
    }
}
