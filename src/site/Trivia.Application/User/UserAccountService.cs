using System;
using System.Collections.Generic;
using System.Text;
using Trivia.Core.User;
using Trivia.Core.User.Infrastructure;
using Trivia.Infrastructure.User.Dtos;

namespace Trivia.Application.User
{
    public class UserAccountService
    {
        private readonly IUserAccountRepository _repo;

        public UserAccountService(IUserAccountRepository repo)
        {
            _repo = repo;
        }

        public class GetAccountResult
        {
            public UserAccountDto Account { get; internal set; }
            public Errors? Error { get; internal set; }

            public enum Errors
            {
                NotFound,
                Technical
            }
        }
        public GetAccountResult GetAccount(string id)
        {
            try
            {
                var account = _repo.Get(id);

                if (account == null)
                    return new GetAccountResult
                    {
                        Account = null,
                        Error = GetAccountResult.Errors.NotFound,
                    };

                return new GetAccountResult
                {
                    Account = MapToDto(account),
                    Error = null
                };
            }
            catch
            {
                //todo: probably would be good to have logging XD
                return new GetAccountResult
                {
                    Account = null,
                    Error = GetAccountResult.Errors.Technical
                };
            }
        }

        public GetAccountResult SearchAccount(string username)
        {
            try
            {
                var account = _repo.Get(username);

                if (account == null)
                    return new GetAccountResult
                    {
                        Account = null,
                        Error = GetAccountResult.Errors.NotFound,
                    };

                return new GetAccountResult
                {
                    Account = MapToDto(account),
                    Error = null
                };
            }
            catch
            {
                //todo: probably would be good to have logging XD
                return new GetAccountResult
                {
                    Account = null,
                    Error = GetAccountResult.Errors.Technical
                };
            }
        }


        private UserAccountDto MapToDto(UserAccount account)
        {
            return new UserAccountDto
            {
                AccountId = account.Id,
                Username = account.Username
            };
        }
    }
}
