using System;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Server.Controllers;

namespace Server.Providers
{
    public  class OAuthHttpModule : IHttpModule
    {
        static volatile bool _applicationStarted = false;
        static readonly object applicationStartLock = new object();

        public void Init(HttpApplication context)
        {
            if (!_applicationStarted)
            {
                lock (applicationStartLock)
                {
                    if (!_applicationStarted) // double check
                    {
                        // OnStart(context); // this will run only once per application start
                        _applicationStarted = true;
                    }
                }
            }
            OnInit(context); // this will run on every HttpApplication initialization in the application pool            
        }

        private void OnInit(HttpApplication context)
        {
            context.AuthenticateRequest += ContextAuthenticateRequest;
        }

        public void Dispose()
        {         
        }
        
        void ContextAuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication context = (HttpApplication)sender;

            if (!context.Request.Headers.AllKeys.Contains("Authorization"))
            {
                return;
            }

            //var headers = context.Request.Headers.AllKeys;
            var authLine = context.Request.Headers["Authorization"];
            if (!authLine.StartsWith("Bearer ")) return;

            //Removed "Bearer "
            var jsonObject = authLine.Substring(7);

            //Remove outer quotes
            jsonObject = jsonObject.Substring(1, jsonObject.Length- 2);

            //var strippedObject =  jsonObject.Replace("%22", "").Replace("\"", "");
            var strippedObject = jsonObject.Replace("%22", "").Replace("\\", "");
            var token = new JavaScriptSerializer().Deserialize<ClientToken>(strippedObject);
            
            var x = token.isClient;

         //   FacadeSecurity.TokenStore.AddOrUpdate(token.access_token , token, (k, v) => v);

            context.Context.User = new OAuthPrincipal(token);            
        }
    }
}