using System.Collections.Generic;

namespace PortfolioManager.DTO.DTOs
{
    public class AccountWithInvestmentsMapDto
    {
        public AccountDto AccountInfo;

        public ICollection<InvestmentDto> Investments;
    }
}