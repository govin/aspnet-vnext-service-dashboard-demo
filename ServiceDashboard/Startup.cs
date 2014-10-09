using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using System.Linq;
using System;
using System.Console;

namespace AspNetVNext.ServiceDashboard
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
           var configuration = new Configuration();
           configuration.AddJsonFile("config.json");

           var serviceUrls = configuration.Get("ServiceUrls").ToString().Split(',').Select(x => x).ToList();
           var servicesConfig = new ServicesConfiguration() { Urls = serviceUrls };

            app.UseErrorPage();

            app.UseServices(services =>
            {
                services.AddMvc();

                services.AddInstance<IServiceStatusProvider>(new ServiceStatusProvider());
                services.AddInstance<IServicesConfiguration>(servicesConfig);
            });

            app.UseStaticFiles();

             app.UseMvc(routes =>
                        {
                            routes.MapRoute(
                                name: "areaRoute",
                                template: "{area:exists}/{controller}/{action}",
                                defaults: new { action = "Index" });

                            routes.MapRoute(
                                name: "default",
                                template: "{controller}/{action}/{id?}",
                                defaults: new { controller = "Home", action = "Index" });

                            routes.MapRoute(
                                name: "api",
                                template: "{controller}/{id?}");
                        });



            app.UseWelcomePage();
        }       
    }
}