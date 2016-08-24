namespace Server.Providers
{
    public class ClientToken
    {
        public string UserId { get; set; }
        public string TokenType { get; set; }

        public bool IsClient { get; set; }
        
        public long TokenCreated { get; set; }
        public string FullName { get; set; }
    }
}