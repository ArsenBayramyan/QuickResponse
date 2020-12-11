using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;

namespace QuickResponse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var responsesConString = Configuration["Data:QuickResponseIdentity:ConnectionString"];
            services.AddDbContext<AppIdentityDBContext>(options =>
               options.UseSqlServer(responsesConString));
            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<AppIdentityDBContext>().AddDefaultTokenProviders();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Post>, PostRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<ProductType>, ProductTypeRepository>();
            services.AddTransient<IUnitOfWOrkRepositroy,UnitOfWorkRepository>();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=PostList}/{id?}");
            });
        }
    }
}
