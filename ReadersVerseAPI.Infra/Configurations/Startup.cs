using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Infra.Configurations
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddHttpContextAccessor();
            //AuthenticationSetup.AddAuthentication(services, Configuration);

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.Cookie.Name = "IdentityCookie";
            //        options.Cookie.Domain = "localhost";
            //        options.Cookie.Path = "/";
            //        options.LoginPath = "/Account/Login";
            //        options.LogoutPath = "/Account/Logout";
            //        options.AccessDeniedPath = "/Account/AccessDenied";
            //        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            //        options.SlidingExpiration = true;
            //    });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
