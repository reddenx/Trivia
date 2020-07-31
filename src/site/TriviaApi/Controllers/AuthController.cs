using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaApi.Security;

namespace TriviaApi.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        [HttpPost("auth/login")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Authenticate([FromBody]LoginInputDto input)
        {
            await HttpContext.SignOutAsync();

            //TODO authenticate using an application service, would look something like this:
            /*
            var authenticationResult = _authService.ValidateLoginCredentials(input.Username, input.Password);
            
            switch(authenticationResult.Error)
            {
                case null:
                    break;
                case AuthenticationResult.Errors.InvalidCredentials:
                    return StatusCode(401);
                case AuthenticationResult.Errors.Technical:
                default:
                    return StatusCode(500);//we're not sure what happened, probably bad
            }

            var principal = AuthorizationContextAccessor.CreateUserContext(authenticationResult.AccountId, authenticationResult.Username, authenticationResult.Roles);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return NoContent();
            */

            //since I didn't bother building the service yet, here's some hardcoded nonsense
            if (input.Username == "admin" && input.Password == "1234")
            {
                var principal = AuthorizationContextAccessor.CreateUserContext(Guid.NewGuid().ToString("N"), "admin", new string[] { AuthRoles.Admin });
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return NoContent();
            }
            else
            {
                return StatusCode(401);
            }
        }
        public class LoginInputDto 
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("auth/logout")]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return NoContent();
        }
    }
}
