using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ControlAccesoBackEnd
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

           

            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute(
                "*", 
                "Origin, X-Requested-With, Content-Type, Accept, Authorization, Cache-Control, If-Modified-Since, Pragma",
            // Allowed methods
            "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(cors);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

      
        }
    }
}
