using Aether.Application.UseCases.User.Implementation.AuthenticateUserCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Application.UseCases.User
{
    /// <summary>
    /// Interface for a command that authenticates the user
    /// </summary>
    public interface IAuthenticateUserCommand : ICommand<AuthenticateUserCommandModel>
    {
    }
}
