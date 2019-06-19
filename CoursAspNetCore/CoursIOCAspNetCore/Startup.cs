using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursIOCAspNetCore.Interfaces;
using CoursIOCAspNetCore.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoursIOCAspNetCore
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
            services.AddMvc();
            //Ajouter un service dans le container de service avec le cycle de vie transient 
            //services.AddTransient<ILogger, SecondLoggerService>();
            //Ajouter un service dans le container de service avec le cycle de vie singleton
            //services.AddSingleton<ILogger, SecondLoggerService>();
            //Ajouter un service dans le container de service avec le cycle de vie Scoped
            services.AddScoped<ILogger, SecondLoggerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
