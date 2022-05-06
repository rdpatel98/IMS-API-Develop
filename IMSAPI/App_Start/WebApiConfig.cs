using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
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

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


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
