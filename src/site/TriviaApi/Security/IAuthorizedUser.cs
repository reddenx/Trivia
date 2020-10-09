using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaApi.Security
{
    public interface IAuthorizedUser
    {
        Guid AccountId { get; }
        string Username { get; }
        string[] Roles { get; }
    }
}
