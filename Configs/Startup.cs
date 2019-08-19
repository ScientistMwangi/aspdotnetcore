using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configs.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Configs
{
    public class Startup
    {
        private IConfiguration  _config;

        public Startup(IConfiguration config)
        {
            _config = config;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //mvc service adding
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvcCore();//add only mvc services

            services.AddMvc();//add all the mvc services //within it it call AddMvcCore()

            //  ==DEPENDANCY INJECTION
            //services.AddSingleton<IEmployeeRespository,MockEmployeeRespository>();
            //AddSingleton failed on SqlEmployeeRepository
            services.AddScoped<IEmployeeRespository, SqlEmployeeRepository>();

            //===CONTENT NEGOTION===
            services.AddMvc().AddXmlSerializerFormatters();

            //==REGISTER CONNECTION STRINGS
            services.AddDbContextPool<AppDBContext>(options=>options.UseSqlServer(_config.GetConnectionString("EmployeeDB")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure set up the environment,it also prepare the app for starting,also implements middleware
        /// i.e loggin authen,static
        /// the app.run take a delagate which takes the HttpContext as aparameter...have both request and response
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        {
            //to see the effect developer exception should be introduced in the pipeline as early as possible
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //to call another middleware use key world use, which take to params as below
            //Reading from files launch,appsetting,appsetting.envi,command,secrets
            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync(_config["MyKey"]);

            //    logger.LogInformation("Response from middleware 1");
            //    await next();
            //    logger.LogInformation("Out going response from middleware 1");
            //});

            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync(_config["MyKey"]);

            //    logger.LogInformation("Response from middleware 2");
            //    await next();
            //    logger.LogInformation("Out going response from middleware 2");
            //});

            //ading another middleware....terminal middle ware does not call other middleware

            //this two functionality allow serving static file from wwwroot directory


            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
           // defaultFilesOptions.DefaultFileNames.Clear();
            //customize the default pages index.htm|html default.htm|html
            //defaultFilesOptions.DefaultFileNames.Add("html/Foo.html");

            //app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();

            //act like usedefaultfile but add file listings with it you dont need UseStaticFiles
            /// app.UseFileServer();


            //configure mvc middleware
            app.UseMvcWithDefaultRoute();

            //==ATTRIBUTE ROUTES==
            //app.UseMvc(routes=>routes.MapRoute("default", "{controller}/{Action}/{id}"));

            //===ATTRIBUTE ROUTE ARE HIERACHICHA== APPLIED ON CONTROLLER AND ACTION

            app.Run(async( context) => {
                //throw new Exception("Throw some error");
                await context.Response.WriteAsync($"Request handled by Middleware 3rd terminal one: Environment:{env.EnvironmentName}");
                logger.LogInformation("Response from  middleware 3 terminal middleware");
            });

            
        }
    }
}
