using System.Collections;
using System.Collections.Generic;

namespace PortfolioManager.DTO
{
    public class AccountInvestmentMapDto
    {
        public AccountDto AccountInfo;

        public ICollection<InvestmentDto> Investments;
    }

    public class AccountInvestmentMapRequest
    {
        public int AccountId;
        public ICollection<int> Investments;
    }
}