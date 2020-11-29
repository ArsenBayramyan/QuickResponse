using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickResponse.Data.Models;

namespace QuickResponse.Data.Contexts
{
    public class AppIdentityDBContext : IdentityDbContext<User, IdentityRole<int>, int> 
    {
        public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }


    }
}
