using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace MPro
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
                var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
                config.Formatters.Add(jsonpFormatter);

                var cors = new EnableCorsAttribute("http://localhost:51131", "*", "GET,POST");
                config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

}
