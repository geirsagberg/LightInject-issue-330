using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using LightInject;
using LightInject_issue_330.Controllers;

namespace LightInject_issue_330
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.Register<IFoo, Foo>();
            container.RegisterApiControllers();
            container.EnablePerWebRequestScope();
            container.EnableWebApi(config);
        }
    }

    public class Bar<T1, T2> : List<T1>, IEnumerable<T1>, IEnumerable, IBar
    {
        
    }

    public interface IBar {}
}
