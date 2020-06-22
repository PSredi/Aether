using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aether.Application.Core;
using Aether.Application.UseCases.User;
using Aether.Application.UseCases.User.Implementation.AuthenticateUserCommand;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aether.Presentation.Pages
{
    public class LoginModel : PageModel
    {
        private IMediator _mediator;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }


        public LoginModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult OnPost()
        {
            if (Email is null || Password is null)
            {
                if (Email is null) ModelState.AddModelError(nameof(Email), "Required field");
                if (Password is null) ModelState.AddModelError(nameof(Password), "Required field");
                return Page();
            }

            var commandModel = new AuthenticateUserCommandModel()
            {
                Email = Email,
                Password = Password
            };

            _mediator.Send<IAuthenticateUserCommand, AuthenticateUserCommandModel>(commandModel);

            if (!commandModel.WasSuccessfull)
            {
                ModelState.AddModelError(string.Empty, "Please check your information!");
                return Page();
            }
            
            return RedirectToPage("/Index");
        }
    }
}