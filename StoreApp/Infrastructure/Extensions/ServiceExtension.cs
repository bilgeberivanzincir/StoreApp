using Entities.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
            options.UseSqlServer(configuration.GetConnectionString("mssqlconnection"),
                b => b.MigrationsAssembly("StoreApp"));

            options.EnableSensitiveDataLogging(true);
            
            });

        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser,IdentityRole>(options => 
            {
                options.SignIn.RequireConfirmedEmail=false; 
                options.User.RequireUniqueEmail=true;
                options.Password.RequireUppercase=false;
                options.Password.RequireLowercase=false;
                options.Password.RequireDigit=false;
                options.Password.RequiredLength=6;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache(); //middleware inşası
            services.AddSession(options =>
            {
                 options.Cookie.Name="StoreApp.Session";
                 options.IdleTimeout=TimeSpan.FromMinutes(10); //10dk işlem yapılmazsa oturum düşer.
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));

        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService,OrderManager>();
            services.AddScoped<IAuthService,AuthManager>();

        }
        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath=new PathString("/Account/Login");
                options.ReturnUrlParameter=CookieAuthenticationDefaults.ReturnUrlParameter; 
                options.ExpireTimeSpan=TimeSpan.FromMinutes(10);
                options.AccessDeniedPath=new PathString("/Account/AccessDenied");

            });
        }

        public static void ConfigureRouting(this IServiceCollection services )
        {
            services.AddRouting(options => 
            {
                options.LowercaseUrls=true;
                options.AppendTrailingSlash=false; //sona slash eklenmesi
            });


        }
    }

}