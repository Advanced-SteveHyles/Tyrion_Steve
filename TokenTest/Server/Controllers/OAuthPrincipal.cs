using System.Security.Principal;

namespace Server.Controllers
{
    public class OAuthPrincipal : IPrincipal
    {
        public AuthController.ClientToken Token { get; }

        public OAuthPrincipal(AuthController.ClientToken token)
        {
            Token = token;
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public IIdentity Identity { get; }
    }
}