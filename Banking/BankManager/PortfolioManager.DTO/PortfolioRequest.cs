namespace PortfolioManager.DTO
{
    public class PortfolioRequest
    {
        public string Name { get; set; }        
    }

    public class AccountRequest
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
    }
}