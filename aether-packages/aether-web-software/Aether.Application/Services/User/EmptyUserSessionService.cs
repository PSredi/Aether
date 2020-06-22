using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Application.Services.User
{
    public class EmptyUserSessionService : IUserSessionService
    {
        public bool IsInSession => false;

        public int CurrentUserID => 0;

        public void EndSession()
        {
        }

        public void StartNewSession([DisallowNull] Domain.Data.Entities.User user)
        {
        }
    }
}
