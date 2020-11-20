using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickResponse.Data.Models;

namespace QuickResponse.Data.Contexts
{
    public class AppIdentityDBContext:IdentityDbContext<User>
    {
        public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        
    }
}
