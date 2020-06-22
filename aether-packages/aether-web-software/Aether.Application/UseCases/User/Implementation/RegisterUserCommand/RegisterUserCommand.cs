using Aether.Application.Data.Repositories;
using Aether.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Aether.Application.UseCases.User.Implementation.RegisterUserCommand
{
    public class RegisterUserCommand : IRegisterUserCommand
    {
        private IRepository<Domain.Data.Entities.User> _userRepository;

        public RegisterUserCommand(IRepository<Domain.Data.Entities.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute([DisallowNull] RegisterUserCommandModel commandModel)
        {
            commandModel.WasSuccessfull = false;
            var existingUser = _userRepository.GetEntities().FirstOrDefault(user => user.Email == commandModel.Email);
            if (existingUser is null)
            {
                if (TryWrapper.Try(() => Domain.Data.Entities.User.CreateNew(commandModel.UserName, commandModel.Email, commandModel.Password), out existingUser))
                {
                    _userRepository.Push(existingUser);
                    commandModel.WasSuccessfull = true;
                }
            }
        }
    }
}
