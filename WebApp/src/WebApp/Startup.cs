using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Rusal.Interfaces.Repository;
using Rusal.Repository;
using WebApp.Security;
using Rusal.Interfaces;
using Microsoft.AspNet.StaticFiles;

namespace WebApp
{
    public class Startup
    {

        public IRepositoryFactory factory;

        public Startup(IHostingEnvironment env)
        {

            factory = new RepositoryFactory("Data Source =.; Initial Catalog = rusal_tasks_db; User ID = sa; Password = 1");

        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(x => factory);
            services.AddScoped   (x => x.GetRequiredService<IRepositoryFactory>().CreateRepository<IUserRepository>());
            services.AddScoped   (x => x.GetRequiredService<IRepositoryFactory>().CreateRepository<ITaskRepository>());

            services.AddScoped<IUserContext>(x => new UserContext(x.GetRequiredService<IUserRepository>()));


            services.AddMvc();
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            app.UseDefaultFiles(new Microsoft.AspNet.StaticFiles.DefaultFilesOptions() { DefaultFileNames = new[] { "index.html" } });

            // Add MVC to the request pipeline.
            app.UseMvc();
            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");

            app.Run(async (context) =>
            {
                await Task.Run(() => context.Response.Redirect("index.html"));
            });
        }
    }
}
