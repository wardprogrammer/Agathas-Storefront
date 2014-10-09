using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Agathas.Storefront.Controllers;
using Agathas.Storefront.Infrastructure.Configuration;
using Agathas.Storefront.Infrastructure.Domain.Events;
using Agathas.Storefront.Infrastructure.Logging;
using Agathas.Storefront.Services;
using log4net.Config;
using StructureMap;
using Agathas.Storefront.Infrastructure.Email;

namespace Agathas.Storefront.UI.Web.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "ProductDetail",                                                // Route name
                "Product/{brand}-{productname}/{id}",                          // URL with parameters
                new { controller = "Product", action = "Detail", id = "" } // Parameter defaults
            );

            routes.MapRoute(
                "Browse",                                                // Route name
                "Category/{category}/{categoryId}",                                  // URL with parameters
                new { controller = "Product", action = "GetProductsByCategory", id = "" } // Parameter defaults
            );
                        
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
            

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            BootStrapper.ConfigureDependencies();

            Controllers.AutoMapperBootStrapper.ConfigureAutoMapper();
            Services.AutoMapperBootStrapper.ConfigureAutoMapper();

            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(ObjectFactory.GetInstance<IApplicationSettings>());

            LoggingFactory.InitializeLogFactory(ObjectFactory.GetInstance<ILogger>());

            EmailServiceFactory.InitializeEmailServiceFactory(ObjectFactory.GetInstance<IEmailService>()); 

            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());

            DomainEvents.DomainEventHandlerFactory = ObjectFactory.GetInstance<IDomainEventHandlerFactory>();
            
            LoggingFactory.GetLogger().Log("Application Started");            
        }
             
    }
}