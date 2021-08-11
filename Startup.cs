using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagment
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.SignIn.RequireConfirmedEmail = true;


            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


           /* services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 10;

            });*/
            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));

            });
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "168756351999-d09qeo8clde36u9qd4qqkr7cln5i8jnu.apps.googleusercontent.com";
                options.ClientSecret = "fJy3RdXWDzJgDuz2ksroLo3k";

            })
            .AddFacebook(options =>
            {
                options.AppId = "230624635588950";
                options.AppSecret = "039e5a388033c2ba3040f873735abff2";
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("EditRolePolicy", policy => policy.RequireClaim("Edit Role"));
            });


            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();







        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");

            }


            //Middleware(PIPELINE)
            /* app.Use(async (context,next) =>
             {
                 logger.LogInformation("MW1:INCOMING REQUEST");
                 await next();
                 logger.LogInformation("MW1: OUTGOING RESPONSE");



             });*/

            //We can create fileserverobject where we can call fileserver methods to call what we want
            /*FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");*/


            //app.UseFileServer();
            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });







            /*app.Run(async (context) =>
            {
                await context.Response
                .WriteAsync("Hello World");

            });*/
        }
    }

}

//System.Diagnostics.Process.GetCurrentProcess().ProcessName