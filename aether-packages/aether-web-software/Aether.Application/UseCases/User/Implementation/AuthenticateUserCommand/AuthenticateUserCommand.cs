using Aether.Application.Data.Repositories;
using Aether.Application.Services.User;
using Aether.Domain.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Aether.Application.UseCases.User.Implementation.AuthenticateUserCommand
{
    public class AuthenticateUserCommand : IAuthenticateUserCommand
    {
        private IRepository<Domain.Data.Entities.User> _userRepository;
        private IUserSessionService _userSessionService;

        public AuthenticateUserCommand(IRepository<Domain.Data.Entities.User> userRepository, IUserSessionService userSessionService)
        {
            _userRepository = userRepository;
            _userSessionService = userSessionService;
        }

        public void Execute([DisallowNull] AuthenticateUserCommandModel commandModel)
        {
            var user = _userRepository.GetEntities().FirstOrDefault(user => user.Email == commandModel.Email);
            commandModel.WasSuccessfull = false;
            if (user is { })
            {
                if (user.TryAuthenticate(commandModel.Password))
                {
                    commandModel.WasSuccessfull = true;
                    _userSessionService.StartNewSession(user);
                }
            }
        }
    }
}
