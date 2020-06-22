using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Application.Services.User
{
    /// <summary>
    /// Service for dealing with user sessions
    /// </summary>
    public interface IUserSessionService
    {
        /// <summary>
        /// Indicates wether a session has been started
        /// </summary>
        bool IsInSession { get; }
        
        /// <summary>
        /// The ID of the user in the current session
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if currently not in session</exception>
        int CurrentUserID { get; }

        /// <summary>
        /// Starts a new session. Ends the previous session
        /// </summary>
        /// <param name="user"></param>
        void StartNewSession([DisallowNull] Domain.Data.Entities.User user);

        /// <summary>
        /// Ends the current session
        /// </summary>
        void EndSession();
    }
}
