﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trivia.Application.Question;
using Trivia.Core.Question.Infrastructure;
using Trivia.Core.User.Infrastructure;
using Trivia.Infrastructure.Question;
using TriviaApi.Security;

namespace TriviaApi.AppStart
{
    public static class DependencyConfiguration
    {
        public static void RegisterApplicationDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<QuestionService>();
            services.AddSingleton<IQuestionRepository, QuestionRepository>();

        }

        //probably extract later to somewhere else /shrug
        public static void RegisterAuthDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    //this is removing redirect behavior, routing will be a front-end concern
                    options.Events.OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                    options.Events.OnRedirectToAccessDenied = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                    options.Cookie.Name = configuration.GetValue<string>("authCookieName");
                    options.Cookie.MaxAge = TimeSpan.FromDays(configuration.GetValue<int>("authCookieExpirationDays"));
                });

            services.AddAuthorization(options => 
            {
                options.AddPolicy(AuthPolicies.Authenticated, policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
                options.AddPolicy(AuthPolicies.Admin, policy => 
                {
                    policy.RequireRole(AuthRoles.Admin);
                });
                options.AddPolicy(AuthPolicies.PermanentAccount, policy =>
                {
                    policy.RequireRole(AuthRoles.PermanentAccount);
                });
            });
        }
    }
}
