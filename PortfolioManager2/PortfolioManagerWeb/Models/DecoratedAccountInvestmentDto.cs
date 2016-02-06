using System.Collections.Generic;
using System.Linq;
using PortfolioManager.DTO;

namespace PortfolioManagerWeb.Models
{
    public  class DecoratedAccountInvestmentDto
    {
        public AccountDto Account { get; }
        public ICollection<InvestmentDecorator> Investments { get; }

        public DecoratedAccountInvestmentDto(AccountInvestmentMapDto x)
        {
            Account = x.AccountInfo;
            Investments = x.Investments.Select(i=> new InvestmentDecorator(i)).ToList();
        }
    }
}