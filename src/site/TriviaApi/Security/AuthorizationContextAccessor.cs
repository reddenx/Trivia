using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TriviaApi.Security
{
    public static class AuthorizationContextAccessor
    {
        private const string AccountIdClaimString = @"trivia.account.accountid";

        public static IAuthorizedUser GetUserContext(this Controller controller)
        {
            if (controller?.HttpContext?.User?.Identity?.IsAuthenticated == true
                && controller.HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var roles = identity.FindAll(c => c.Type == ClaimTypes.Role);
                var name = identity.FindFirst(c => c.Type == ClaimTypes.Name);
                var accountId = identity.FindFirst(c => c.Type == AccountIdClaimString);

                return new AuthorizedUser(
                    username: name.Value,
                    roles: roles.Select(r => r.Value).ToArray(),
                    accountId: accountId.Value);
            }
            else
            {
                return null;
            }
        }

        public static ClaimsPrincipal CreateUserContext(string accountId, string username, string[] roles)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(ClaimTypes.Name, username));
            identity.AddClaim(new Claim(AccountIdClaimString, accountId));
            
            foreach(var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var principal = new ClaimsPrincipal(identity);
            return principal;
        }

        private class AuthorizedUser : IAuthorizedUser
        {
            public string Username { get; }
            public string[] Roles { get; }
            public string AccountId { get; }


            public AuthorizedUser(string username, string[] roles, string accountId)
            {
                Username = username;
                Roles = roles;
                AccountId = accountId;
            }
        }
    }

}
