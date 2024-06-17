using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Products_Inc.Models;
using Products_Inc.Data;
using Products_Inc.Models.Interfaces;
using Products_Inc.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Microsoft.AspNetCore.Http;
using Products_Inc.Models.Exceptions;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace Products_Inc
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get;  }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment iWebHostEnvironment)
        {
            Configuration = configuration;
            Environment = iWebHostEnvironment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            // -------- DBContexts etc start------- For MySQL server 8.0.27

            //var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            services.AddDbContext<ApplicationDbContext>(options =>
                 //options.UseSqlServer(
                 //    Configuration.GetConnectionString("ProductIncConnection")));

                 options.UseSqlServer(
                     Configuration.GetConnectionString("ProductIncConnection"))
                     //, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                //.LogTo(Console.WriteLine, LogLevel.Information)
                //.EnableSensitiveDataLogging()
                //.EnableDetailedErrors()
        );


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



            //---- for react

            services.AddReact();

            services.AddJsEngineSwitcher(options =>
            {
                options.DefaultEngineName = V8JsEngine.EngineName;
                options.EngineFactories.AddV8();
            } );




            // ------ Identity part start ------------
       

            services.AddIdentity<User, IdentityRole>(o =>
                o.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });


            // ------ Cookie for Redux + store keys + protected -------------------

            var keysFolder = Path.Combine(Environment.ContentRootPath, "Keys");

            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(keysFolder))
                .SetApplicationName("SharedCookieApp");

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".AspNet.productincproject.er";
                options.LoginPath = $"/user/login";
                options.LogoutPath = $"/user/logout";
                options.AccessDeniedPath = $"/user/accessdenied";
            });

           

            // ----- DI stuff ----
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddSingleton<ImageServiceOptions>(new ImageServiceOptions(Environment.WebRootPath, "img", "jpg"));
            services.AddScoped<IShoppingCartRepo, DbShoppingCartRepo>(); 
            services.AddScoped<IOrderRepo, DbOrderRepo>(); 
            services.AddScoped<IProductRepo, DbProductRepo>();



            services.AddRazorPages();

            services.AddControllers(options =>
            options.Filters.Add(new HttpResponseExceptionFilter()));
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();


            // Initialise ReactJS.NET. Must be before static files.
            app.UseReact(config =>
            {
                config
                    .SetReuseJavaScriptEngines(true)
                    .SetLoadBabel(false)
                    .SetLoadReact(false)
                    .SetReactAppBuildPath("~/reactjs/dist")
                    .AddScriptWithoutTransform("~/reactjs/dist/runtime.js")
                    .AddScriptWithoutTransform("~/reactjs/dist/vendor.js")
                    .AddScriptWithoutTransform("~/reactjs/dist/main.js");

            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();



            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute("default", "{path?}", new { controller = "Home", action = "Index" });


                //endpoints.MapControllerRoute(
                //name: "default",
                //pattern: "{controller=Home}/{action=Index}");

                endpoints.MapRazorPages();


            });


        }
    }
}
