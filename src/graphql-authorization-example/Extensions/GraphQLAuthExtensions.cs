using GraphQL.Authorization;
using GraphQL.Server;
using GraphQL.Validation;
using graphql_authorization_example.Authorize;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Security.Claims;

namespace graphql_authorization_example.Extensions
{
    public static class GraphQLAuthExtensions
    {
        public static void AddGraphQLAuth(this IServiceCollection services)
        {
            services.AddGraphQLAuth(options =>
            {
                options.AddPolicy(AuthorizePolicy.Admin, p =>
                {
                    p.RequireClaim(ClaimTypes.Role, "admin");
                });
                options.AddPolicy(AuthorizePolicy.Email, p =>
                {
                    p.RequireClaim(ClaimTypes.Email);
                    p.RequireClaim(ClaimTypes.GivenName);
                });
            });

            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                 .AddUserContextBuilder(httpContext =>
                 {
                     if (httpContext.User.Identity.IsAuthenticated)
                     {
                         return new GraphQLUserContext { User = httpContext.User };
                     }
                     else
                     {
                         var result = httpContext.AuthenticateAsync().GetAwaiter().GetResult();
                         if (result.Succeeded)
                         {
                             httpContext.User = result.Principal;
                         }
                         return new GraphQLUserContext { User = result.Principal };
                     }
                 });
        }

        public static void AddGraphQLAuth(this IServiceCollection services, Action<AuthorizationSettings> configure)
        {

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();

            services.TryAddSingleton(s =>
            {
                var authSettings = new AuthorizationSettings();
                configure(authSettings);
                return authSettings;
            });
        }
    }
}
