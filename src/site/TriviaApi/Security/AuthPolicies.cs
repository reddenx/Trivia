using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaApi.Security
{
    public static class AuthPolicies
    {
        public const string Admin = "admin";
        public const string PermanentAccount = "account_holder";
        public const string Authenticated = "IsAuthenticated";
        //expand to more INFRASTRUCTURE authorization roles (not application permissions, those are managed in service layers)

    }
}
