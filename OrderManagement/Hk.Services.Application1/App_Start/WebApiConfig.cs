using Hk.Services.Application1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Hk.Services.Application1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute("API", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });


            //Custom API Exception
            config.Filters.Add(new CustomApiErrorFilter());
        }
    }
}
