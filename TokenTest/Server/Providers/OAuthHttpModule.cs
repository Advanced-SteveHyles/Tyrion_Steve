using System;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using Server.Controllers;

namespace Server.Providers
{
    //This module is called first and intercepts all calls
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

        public void Dispose() {}

        void ContextAuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication context = (HttpApplication)sender;

            //This is needed because the Server is handling both controllers.
            if (!context.Request.Headers.AllKeys.Contains("Authorization"))
            {
                return;
            }

            var authorization = context.Request.Headers["Authorization"];
            if (!authorization.StartsWith("Bearer ")) return;

            CreateUserFromRequest(context, authorization);
        }

        private static void CreateUserFromRequest(HttpApplication context, string authorization)
        {
           //Remove "Bearer "
            var jsonObject = authorization.Substring(7);

            //Remove outer quotes
            jsonObject = jsonObject.Substring(1, jsonObject.Length - 2);

            //Remove strange characters
            var strippedObject = jsonObject.Replace("%22", "").Replace("\\", "");

            //Convert to JSON
            var token = new JavaScriptSerializer().Deserialize<ClientToken>(strippedObject);
            
            if ((int)DateTime.Now.TimeOfDay.TotalSeconds >  token.TokenCreated + 5 )
            {
                //Token Expired
                return;
            }

            //Create an authenticated principal
            context.Context.User = new OAuthPrincipal(token);
        }
    }
}