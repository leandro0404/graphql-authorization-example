using GraphQL;
using graphql_authorization_example.GraphQL;
using Microsoft.Extensions.DependencyInjection;

namespace graphql_authorization_example.Extensions
{
    public static class GraphQLExtensions
    {
        public static void AddGraphQLResolve(this IServiceCollection services)
        {
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<BaseSchema>();

        }
    }
}
