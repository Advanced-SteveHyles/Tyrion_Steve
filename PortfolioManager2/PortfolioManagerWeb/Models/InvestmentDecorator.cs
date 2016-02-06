using PortfolioManager.DTO;
using PortfolioManagerWeb.Controllers;

namespace PortfolioManagerWeb.Models
{
    public class InvestmentDecorator : ISelectable
    {
        public InvestmentDto Investment { get; }
        private readonly AccountInvestmentMapDto _accountInvestmentMap;
        public InvestmentDecorator(InvestmentDto investment)
        {
            this.Investment = investment;
            this.IsSelected = false;
        }

        public InvestmentDecorator(AccountInvestmentMapDto accountInvestmentMap)
        {
            _accountInvestmentMap = accountInvestmentMap;
        }

        public bool IsSelected { get; set; }
    }
}