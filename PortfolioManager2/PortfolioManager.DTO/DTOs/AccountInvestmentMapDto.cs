using System.Collections.Generic;

namespace PortfolioManager.DTO.DTOs
{
    public class AccountInvestmentMapDto
    {
        public AccountDto AccountInfo;

        public ICollection<InvestmentDto> Investments;
    }
}