using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.Core.User.Infrastructure
{
    public interface IUserAccountRepository
    {
        UserAccount Get(string id);
        UserAccount GetByUsername(string username);
        UserAccount Save();
    }
}
