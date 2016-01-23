using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using PortfolioManager.DTO;

namespace Portfolio_API.Controllers
{
    internal class FakeData
    {
        private readonly EntityToDtoMap _entityToDtoMap = new EntityToDtoMap();

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
                    },
            { new InvestmentEnt
                        {
                            ID = 4,
                            Name = "Legal & General US Index",
                            Symbol = "C1235",
                            Type = "OEIC",
                            Class ="C",
                            Income = "Income",
                            SubType2 = "Core tracker"
                        }
                    },
    };

        public static List<InvestmentMapEnt> InvestmentsMap { get; } = new List<InvestmentMapEnt>
        {
            new InvestmentMapEnt
            {
                Id = 1,
                AccountId = 1,
                InvestmentId = 1,
                Quantity =100,
                SellPrice =1,
                Valuation = 100
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

    

        public static List<PortfolioEnt> GetPortfolios()
        {
            return Portfolios;
        }

        public static AccountEnt GetAccountWithInvestments(int id)
        {
            var accountWithInvestments = GetAccount(id);
            accountWithInvestments.Investments = GetInvestments(id);

            return accountWithInvestments;
        }

        private static ICollection<InvestmentMapEnt> GetInvestments(int id)
        {
            return InvestmentsMap.Where(i => i.AccountId == id).ToList();
        }

        public static AccountEnt GetAccount(int id)
        {
            return Accounts.SingleOrDefault(p => p.Id == id);
        }
    }

}