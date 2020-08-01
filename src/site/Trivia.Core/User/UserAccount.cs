using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.Core.User
{
    public class UserAccount
    {
        public string Id { get; private set; }
        public string Username { get; private set; }

        private const int MIN_USERNAME_LENGTH = 3;

        internal UserAccount(string id)
        {
            this.Id = id;
        }

        public bool UpdateUsername(string username)
        {
            //validate
            if (string.IsNullOrWhiteSpace(username)
                || username.Length < MIN_USERNAME_LENGTH)
                return false;

            this.Username = username;

            //TODO: this is where I'd normally queue a domain event if I bothered creating a domain eventing system /shrug

            return true;
        }
    }
}
