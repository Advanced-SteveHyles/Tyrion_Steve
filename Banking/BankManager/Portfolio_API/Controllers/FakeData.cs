using System.Collections.Generic;
using PortfolioManager.DTO;

namespace Portfolio_API.Controllers
{    
    internal class FakeData
    {
        public static List<PortfolioDTO> Portfolios { get; } = new List<PortfolioDTO>
        {
            {
                new PortfolioDTO
                {
                    Id = 1,
                    Name = "Portfolio 1"
                }
            },
            {
                new PortfolioDTO
                {
                    Id = 2,
                    Name = "Portfolio 1"
                }
            }
        };

        public List<AccountDto> Accounts { get; } = new List<AccountDto>
        {
            new AccountDto
            {
                Id = 1
            },
            new AccountDto
            {
                Id = 2
            },
            new AccountDto
            {
                Id = 3
            },
        };

}
}