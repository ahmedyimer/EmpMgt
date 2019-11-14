using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
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

            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeDBConnection")));
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddControllersWithViews().AddXmlDataContractSerializerFormatters();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 10;
            //    options.Password.RequiredUniqueChars = 3;
            //    options.Password.RequireNonAlphanumeric = false;
            //});

            //or
            //services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //{
            //    options.Password.RequiredLength = 10;
            //    options.Password.RequiredUniqueChars = 3;
            //    options.Password.RequireNonAlphanumeric = false;
            //})
            //.AddEntityFrameworkStores<AppDbContext>();



            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});



            //services.AddControllersWithViews();




            //services.AddMvc();
            //services.AddMvcCore();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);




            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();




            //services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();
            //services.AddTransient<IEmployeeRepository, MockEmployeeRepository>();
            //The controller to be able to return data in XML format
            //services.AddMvc().AddXmlSerializerFormatters();

            //To set authorization globally
            //services.AddMvc(config => {
            //    var policy = new AuthorizationPolicyBuilder()
            //                    .RequireAuthenticatedUser()
            //                    .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            // If the environment is Development serve Developer Exception Page
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();

                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 10
                };
                //app.UseStatusCodePages();
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                //app.UseStatusCodePagesWithReExecute("/Error/{0}");

                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }
            // else serve User Friendly Error Page with Application Support Contact Info
            else if (env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
            {
                //app.UseStatusCodePages();
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                //app.UseStatusCodePagesWithReExecute("/Error/{0}");

                //app.UseExceptionHandler("/Home/Error");
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseDefaultFiles();

            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");
            //// Add Default Files Middleware
            //app.UseDefaultFiles(defaultFilesOptions);


            // Use UseFileServer instead of UseDefaultFiles & UseStaticFiles
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseFileServer(fileServerOptions);

            app.UseStaticFiles();
            app.UseAuthentication();

            //app.Run(async (context) =>
            //{
            //    //throw new Exception("Some error processing the request");
            //    //await context.Response.WriteAsync("Hello World!");
            //    await context.Response.WriteAsync("Hosting Environment: " + env.EnvironmentName);
            //});

            //app.Use(async (context, next) =>
            //    {
            //        logger.LogInformation("MW1: Incoming Request");
            //        await next();
            //        logger.LogInformation("MW1: Outgoing Response");
            //    });

            //app.Use(async (context, next) =>
            //    {
            //        logger.LogInformation("MW2: Incoming Request");
            //        await next();
            //        logger.LogInformation("MW2: Outgoing Response");
            //    });

            //  app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("MW3: Request handled and response produced");
            //        logger.LogInformation("MW3: Request handled and response produced");
            //    });

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();

            //app.UseMvc()

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }
}


