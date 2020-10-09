using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.Infrastructure.User.Dtos
{
    public class UserAccountDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
