using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;

namespace ExpenseTracker.API
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "DefaultRouting",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            //Ny Default web API support both JSON and XML.
            //    ForceDefaultToJson(config);
            
            TurnOffSupportForXml(config);
            TurnOnPatchJson(config);

            FormatterForJson(config);

            return config;
             
        }

        private static void TurnOnPatchJson(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("application/json-patch+json"));
        }

        private static void FormatterForJson(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static void TurnOffSupportForXml(HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();                 
        }

        private static void ForceDefaultToJson(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
