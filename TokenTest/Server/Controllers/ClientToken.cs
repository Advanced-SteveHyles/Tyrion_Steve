namespace Server.Controllers
{
    public class ClientToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }

        public bool isClient { get; set; }
        
        public long TokenCreated { get; set; }
        public string FullName { get; set; }
    }
}