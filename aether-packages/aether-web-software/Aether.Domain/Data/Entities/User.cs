using Aether.Domain.Data.ValueObjects;
using Aether.Domain.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Domain.Data.Entities
{
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The users ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// The users name
        /// </summary>
        [DisallowNull]
        public string UserName { get; set; }

        /// <summary>
        /// The users email
        /// </summary>
        [DisallowNull]
        public string Email { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        [DisallowNull]
        public string Password { get; set; }

        internal User(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public bool TryAuthenticate(string password) =>
            PasswordService.AreEqual(Password, password);

        /// <summary>
        /// Creates a new <see cref="Aether.Domain.Data.Entities.User"/>
        /// </summary>
        /// <param name="userName">The users name</param>
        /// <param name="email">The users email</param>
        /// <param name="plainTextPassword">The users password</param>
        /// <returns></returns>
        public static User CreateNew(string userName, string email, string plainTextPassword)
        {
            plainTextPassword = PasswordService.CreateFrom(plainTextPassword);
            return new User(userName, email, plainTextPassword);
        }

    }
}
