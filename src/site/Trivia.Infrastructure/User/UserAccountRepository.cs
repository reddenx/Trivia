using System;
using System.Collections.Generic;
using System.Text;
using Trivia.Core.User;
using Trivia.Core.User.Infrastructure;

namespace Trivia.Infrastructure.User
{
    public class UserAccountRepository : IUserAccountRepository
    {
        public UserAccount Get(string id)
        {
            throw new NotImplementedException();
        }

        public UserAccount GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public UserAccount Save()
        {
            throw new NotImplementedException();
        }
    }
}
