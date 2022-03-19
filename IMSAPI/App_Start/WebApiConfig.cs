using System.Web.Http;
using System.Web.Http.Cors;

namespace IMSAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
#if DEBUG
            // Web API configuration and services
            EnableCorsAttribute cors = new EnableCorsAttribute("*", headers: "*", methods: "*");
            config.EnableCors(cors);
#endif

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{recent}",
                defaults: new { id = RouteParameter.Optional, recent = RouteParameter.Optional }
            );
        }
    }
}
