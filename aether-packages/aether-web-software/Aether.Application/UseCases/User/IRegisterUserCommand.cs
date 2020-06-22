using Aether.Application.UseCases.User.Implementation.RegisterUserCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Application.UseCases.User
{
    /// <summary>
    /// Interface for a command that registers a new user
    /// </summary>
    public interface IRegisterUserCommand : ICommand<RegisterUserCommandModel>
    {
    }
}
