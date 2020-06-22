using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Application.UseCases.User.Implementation.RegisterUserCommand
{
    public class RegisterUserCommandModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public bool WasSuccessfull { get; set; }
    }
}
