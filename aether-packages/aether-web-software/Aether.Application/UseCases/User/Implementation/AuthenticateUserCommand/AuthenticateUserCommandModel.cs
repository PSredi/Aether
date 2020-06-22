using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Application.UseCases.User.Implementation.AuthenticateUserCommand
{
    public class AuthenticateUserCommandModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool WasSuccessfull { get; set; }
    }
}
