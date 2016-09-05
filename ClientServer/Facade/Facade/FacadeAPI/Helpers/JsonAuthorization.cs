using System;
using System.Text;
using Effortless.Net.Encryption;
using Legal.PortalFacade.Controllers;
using Newtonsoft.Json;

namespace FacadeAPI.Helpers
{
    public static class JsonAuthorization  
    {
        private static readonly byte[] Key = Bytes.GenerateKey();
        private static readonly byte[] Iv = Bytes.GenerateIV();

        public static string Encrypt(ServerToken serverToken)
        {
            var serialisedToken = JsonConvert.SerializeObject(serverToken);
            var encrypted = Strings.Encrypt(serialisedToken, Key, Iv);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(encrypted));

        }

        public static ServerToken Decrypt(string serverToken)
        {
            var asciiString = new StringBuilder();
            foreach (var charAsByte in Convert.FromBase64String(serverToken))
            {
                asciiString.Append((char) charAsByte);
            }
            
            try
            {
                var decrypted = Strings.Decrypt(asciiString.ToString(), Key, Iv);
                return JsonConvert.DeserializeObject<ServerToken>(decrypted);
            }
            catch (Exception)
            {
                return null; // so no token is returned
            }
            
        }
    }
}