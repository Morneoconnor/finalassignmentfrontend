using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CPUTUserManager.Component.Interface;
using CPUTUserManager.Component;
using CPUTUserManager.Sidecar.RestSharp.Interface;
using CPUTUserManager.Sidecar.RestSharp;

namespace CPUTUserManager
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
            string endPoint = Configuration.GetSection("EndPoints:EndPoint").Value;
            var endPointConnection = new EndPoint(endPoint);
            services.AddSingleton<IEndPoint>(endPointConnection);
            services.AddSingleton<IRestBroker, RestBroker>();           
            services.AddSingleton<IHomeComponent, HomeComponent>();
            services.AddSingleton<IContentComponent, ContentComponent>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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
