using GraphQL.Authorization;
using System.Security.Claims;

namespace graphql_authorization_example.Authorize
{
    public class GraphQLUserContext : IProvideClaimsPrincipal
    {
        public ClaimsPrincipal User { get; set; }
    }
}
