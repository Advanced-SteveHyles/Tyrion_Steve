using System.Collections.Generic;
using System.Linq;
using Entities;
using PortfolioManager.DTO;

namespace Portfolio_API.Controllers
{
    internal class FakeData
    {
        private readonly Map _map = new Map();

        private static List<PortfolioEnt> Portfolios { get; } = new List<PortfolioEnt>
        {
            {
                new PortfolioEnt
                {
                    Id = 1,
                    Name = "Steve"
                }
            },
            {
                new PortfolioEnt
                {
                    Id = 2,
                    Name = "Maggie"
                }
            }
        };

        private static List<AccountEnt> Accounts { get; } = new List<AccountEnt>
        {
            new AccountEnt
            {
                Id = 1,
                PortfolioId = 1,
                Name="Stocks & Shares",
                Valuation = 10,
                Type ="ISA"
            },
            new AccountEnt
            {
                Id = 2,
                PortfolioId = 1,
                Name="SIPP",
                Valuation = 12,
                Type ="SIPP"
            },
            new AccountEnt
            {
                Id = 3,
                PortfolioId = 2,
                Name="SIPP",
                Valuation = 0,
                  Type ="SIPP"
            },
            new AccountEnt
            {
                Id = 4,
                PortfolioId = 1,
                Name="Company Pension",
                Cash =0,
                Valuation = 0,
                Type ="Pension"
            }
            ,
            new AccountEnt
            {
                Id = 5,
                PortfolioId = 1,
                Name="Trading Account",
                Valuation = 0,
                Type ="Self-Exec-Trading"
            },
        };

        private static List<InvestmentEnt> Investments { get; } = new List<InvestmentEnt>
        {
            {
                new InvestmentEnt
                        {
                            ID = 1,
                            Name = "Legal & General US Index",
                            Symbol = "T1235",
                            Type = "OEIC",
                            Class ="C",
                            Income = "Accumulation",
                            SubType2 = "Core tracker"
                        }
                    },
                    {
                        new InvestmentEnt
                        {
                            ID = 2,
                            Name = "Investment 2",
                            Symbol = "X1235",
                            Type = "OEIC",
                             Class ="C",
                            Income = "Income",
                            SubType2 = "Core tracker"
                        }
},
                    {
                        new InvestmentEnt
                        {
                            ID = 3,
                            Name = " HL Multi - Manager Equity & Bond Trust",
                            Symbol = "X1234",
                            Type = "Fund",
                             Class ="M",
                            Income = "Accumulation",
                            SubType2 = "Mixed"

                        }
                    }
    };

        public static List<InvestmentMapEnt> InvestmentsMap { get; } = new List<InvestmentMapEnt>
        {
            new InvestmentMapEnt
            {
                AccountId = 1,
                InvestmentId = 1
            }
        };


        public static Entities.PortfolioEnt GetPortfolioWithAccounts(int portfolioId)
        {
            var x = GetPortfolio(portfolioId);
            x.Accounts = GetAccounts(portfolioId);
            return x;
        }

        public static Entities.PortfolioEnt GetPortfolio(int id)
        {
            return Portfolios.SingleOrDefault(p => p.Id == id);
        }
        public static ICollection<AccountEnt> GetAccounts(int portfolioId)
        {
            return (ICollection<AccountEnt>)Accounts.Where(p => p.PortfolioId == portfolioId).ToList();
        }


        public static List<Entities.InvestmentEnt> GetInvestments()
        {
            return Investments;                         
        }

        public IEnumerable<PortfolioDto> MapEntitiesToDtoModelsSorted(Entities.PortfolioEnt portfolioEnt, string sort, int statusId, string userId)
        {
            //Uses Dynamic linq
            return Portfolios
                //.Where(eg => (statusId == DomainMappers.AllStatusus || eg.ExpenseGroupStatusId == statusId))
                //.Where(eg => (userId == null || eg.UserId == userId))
                //.ApplySort(sort)
                .ToList()
                .Select(p => Map.CreatePortfolio(p)
                );
        }


        public IEnumerable<object> MapEntitiesToDtoModelsSortedShaped(IQueryable<Entities.PortfolioEnt> portfolio, string sort, int statusId, string userId, List<string> fields)
        {
            //Uses Dynamic linq
            return portfolio
                //.Where(eg => (statusId == DomainMappers.AllStatusus || eg.ExpenseGroupStatusId == statusId))
                //.Where(eg => (userId == null || eg.UserId == userId))
                //.ApplySort(sort)
                .ToList()
                .Select(eg => ShapedData.CreateDataShapedObject(eg, fields)
                );
        }

        public static List<PortfolioEnt> GetPortfolios()
        {
            return Portfolios;
        }
    }

}