using System.Security.Principal;
using Server.Providers;

namespace Server.Controllers
{

    //This is a wrapper for the Identity
    public class OAuthPrincipal : IPrincipal
    {        
        public OAuthPrincipal(ClientToken token)
        {
            Identity = new OAuthIdentity(token);            
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public IIdentity Identity { get; }
    }
}