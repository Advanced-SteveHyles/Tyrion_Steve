using System.Collections.Generic;
using System.Linq;
using PortfolioManager.DTO;
using PortfolioManager.DTO.DTOs.Transactions;
using PortfolioManager.Repository.Entities;

namespace Portfolio_API.Controllers
{
    internal static class EntityToDtoMap
    {
            public static PortfolioDto MapToDto(this Portfolio entity)
            {
                return new PortfolioDto
                {
                    PortfolioId = entity.PortfolioId,
                    Name = entity.Name,

                    //        Accounts = portfolioEnt.Accounts.Select(e => CreateAccount(e, false)).ToList()
                };
            }


//public static InvestmentMapDto CreateInvestmentMap(InvestmentMapEnt investmentMapEnt)
        //{
        //    return new InvestmentMapDto
        //    {
        //        PortfolioId =investmentMapEnt.PortfolioId,
        //        AccountId = investmentMapEnt.AccountId,
        //        InvestmentId = investmentMapEnt.InvestmentId,
        //        InvestmentName = investmentMapEnt.InvestmentName,
        //        Quantity = investmentMapEnt.Quantity,
        //        SellPrice = investmentMapEnt.SellPrice,
        //        Valuation = investmentMapEnt.Valuation,

        //    };
        //}



        //public static InvestmentDto CreateInvestment(InvestmentEnt investmentEnt)
        //{
        //    return new InvestmentDto()
        //    {
        //        PortfolioId = investmentEnt.ID,
        //        Name = investmentEnt.Name,
        //        Symbol = investmentEnt.Symbol,
        //        Type = investmentEnt.Type,
        //        Class = investmentEnt.Class,
        //        Income = investmentEnt.Income,
        //        SubType2 = investmentEnt.SubType2
        //    };
        //}

        //public IEnumerable<PortfolioDto> MapEntitiesToDtoModelsSorted(Entities.PortfolioEnt portfolioEnt, string sort, int statusId, string userId)
        //{
        //    //Uses Dynamic linq
        //    return Portfolios
        //        //.Where(eg => (statusId == DomainMappers.AllStatusus || eg.ExpenseGroupStatusId == statusId))
        //        //.Where(eg => (userId == null || eg.UserId == userId))
        //        //.ApplySort(sort)
        //        .ToList()
        //        .Select(p => EntityToDtoMap.CreatePortfolio(p)
        //        );
        //}


        //public IEnumerable<object> MapEntitiesToDtoModelsSortedShaped(IQueryable<Entities.PortfolioEnt> portfolio, string sort, int statusId, string userId, List<string> fields)
        //{
        //    //Uses Dynamic linq
        //    return portfolio
        //        //.Where(eg => (statusId == DomainMappers.AllStatusus || eg.ExpenseGroupStatusId == statusId))
        //        //.Where(eg => (userId == null || eg.UserId == userId))
        //        //.ApplySort(sort)
        //        .ToList()
        //        .Select(eg => ShapedData.CreateDataShapedObject(eg, fields)
        //        );
        //}


        public static AccountDto MapToDto(this Account entity)
        {
            return new AccountDto()
            {
                AccountId = entity.AccountId,
                Name = entity.Name,                
                Type =  entity.Type,
                Cash = entity.Cash,
                Valuation =  entity.Valuation,
                AccountBalance = entity.Cash,
                PortfolioId = entity.PortfolioId

                //  Accounts = portfolioEnt.Accounts.Select(e => CreateAccount(e, false)).ToList()
            };
        }

        //public static AccountDto CreateAccount(AccountEnt accountEnt, bool includeInvestments)
        //{
        //    var accountDto = new AccountDto
        //    {
        //        PortfolioId = accountEnt.PortfolioId,
        //        Name = accountEnt.Name,
        //        Cash = accountEnt.Cash,
        //        Valuation = accountEnt.Valuation              
        //    };

        //    if (includeInvestments)
        //        accountDto.Investments = accountEnt.Investments.Select(e => CreateInvestmentMap(e)).ToList();

        //    return accountDto;
        //}


        public static TransactionDto MapTransactionToDto(object entity)
        {
            throw new System.NotImplementedException();
        }

        public static InvestmentDto MapInvestmentToDto(Investment entity)
        {
            return new InvestmentDto
            {
                Name = entity.Name,
                Symbol = entity.Symbol,
                Type = entity.Type,
                Class = entity.Class,
                IncomeType = entity.IncomeType,
                MarketIndex = entity.MarketIndex
            };
        }

        public static InvestmentDto MapToDto(this Investment entity)
        {
            return new InvestmentDto
            {
                InvestmentId =  entity.InvestmentId,
                Name = entity.Name,
                Symbol = entity.Symbol,
                Type = entity.Type,
                Class = entity.Class,
                IncomeType = entity.IncomeType,
                MarketIndex = entity.MarketIndex
            };
        }

    }
}