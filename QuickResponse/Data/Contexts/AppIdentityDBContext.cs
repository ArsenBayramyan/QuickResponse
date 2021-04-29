using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QuickResponse.Data.Models;
using System.IO;

namespace QuickResponse.Data.Contexts
{
    public class AppIdentityDBContext : IdentityDbContext<User, IdentityRole<int>,int> 
    {
        public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<AppIdentityDBContext>
        {
            AppIdentityDBContext IDesignTimeDbContextFactory<AppIdentityDBContext>.CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<AppIdentityDBContext>();
                var connectionString = configuration["Data:QuickResponseIdentity:ConnectionString"];
                builder.UseSqlServer(connectionString);
                return new AppIdentityDBContext(builder.Options);
            }
        }

    }
}
