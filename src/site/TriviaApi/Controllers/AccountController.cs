using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trivia.Application.Account;
using Trivia.Infrastructure.User.Dtos;
using TriviaApi.Security;

namespace TriviaApi.Controllers
{
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id}")]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(UserAccountDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult GetById([FromRoute]string id)
        {
            var result = _accountService.GetAccount(id);
            switch(result.Error)
            {
                case null:
                    break;
                case AccountService.GetAccountResult.Errors.NotFound:
                    return StatusCode(404);
                case AccountService.GetAccountResult.Errors.Technical:
                default:
                    return StatusCode(500);
            }

            //only admins can get users other than themselves
            var authUserContext = this.GetUserContext();
            if (authUserContext.AccountId != result.Account.AccountId
                && !authUserContext.Roles.Contains(AuthRoles.Admin))
            {
                return StatusCode(403);
            }
            return Ok(result.Account);
        }


        [HttpGet("username/{username}")]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(UserAccountDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult GetByUsername([FromRoute]string username)
        {
            //yeah yeah this is pretty copypasta, but there should eventually be differences

            var result = _accountService.SearchAccount(username);
            switch (result.Error)
            {
                case null:
                    break;
                case AccountService.GetAccountResult.Errors.NotFound:
                    return StatusCode(404);
                case AccountService.GetAccountResult.Errors.Technical:
                default:
                    return StatusCode(500);

            }

            //only admins can get users other than themselves
            var authUserContext = this.GetUserContext();
            if (authUserContext.AccountId != result.Account.AccountId
                && !authUserContext.Roles.Contains(AuthRoles.Admin))
            {
                return StatusCode(403);
            }
            return Ok(result.Account);
        }
    }
}
