using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.Core.User
{
    public class UserAccountFactory
    {
        public UserAccount Create(string username)
        {
            return new UserAccount(Guid.NewGuid());
        }

        public UserAccount Hydrate(Guid id, string username)
        {
            var account = new UserAccount(id);
            var valid = account.UpdateUsername(username);

            if (valid)
            {
                //TODO, if we had domain event queuing, you'd have to be sure to clear domain events before handing off the user
                return account;
            }

            return null;
        }
    }
}
