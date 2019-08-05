using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace graphql_authorization_example.Data
{
    public class DemoTokenContext : IdentityDbContext
    {
        public DemoTokenContext(DbContextOptions<DemoTokenContext> options)
            : base(options)
        {
        }

    }
}
