using System;
using System.Security.Principal;
using Server.Controllers;

namespace Server.Providers
{
    //This is who we are dealing with and wraps the token.
    public class OAuthIdentity : IIdentity
    {
        private readonly ClientToken _clientToken;

        public OAuthIdentity(ClientToken clientToken)
        {
            _clientToken = clientToken;            
        }

        public string Name => _clientToken.FullName;

        public bool IsClient => _clientToken.isClient;

        public string AuthenticationType => "OAuth";

        public bool IsAuthenticated => true;        
    }
}