using System.Collections.Generic;
using System.Linq;
using Entities;
using PortfolioManager.DTO;

namespace Portfolio_API.Controllers
{
    internal class EntityToDtoMap
    {
        //public static AccountDto CreateAccount(AccountEnt accountEnt, bool includeInvestments)
        //{
        //    var accountDto = new AccountDto
        //    {
        //        Id = accountEnt.Id,
        //        Name = accountEnt.Name,
        //        Cash = accountEnt.Cash,
        //        Valuation = accountEnt.Valuation              
        //    };

        //    if (includeInvestments)
        //        accountDto.Investments = accountEnt.Investments.Select(e => CreateInvestmentMap(e)).ToList();

        //    return accountDto;
        //}

        //public static InvestmentMapDto CreateInvestmentMap(InvestmentMapEnt investmentMapEnt)
        //{
        //    return new InvestmentMapDto
        //    {
        //        Id =investmentMapEnt.Id,
        //        AccountId = investmentMapEnt.AccountId,
        //        InvestmentId = investmentMapEnt.InvestmentId,
        //        InvestmentName = investmentMapEnt.InvestmentName,
        //        Quantity = investmentMapEnt.Quantity,
        //        SellPrice = investmentMapEnt.SellPrice,
        //        Valuation = investmentMapEnt.Valuation,

        //    };
        //}

        //public static PortfolioDto CreatePortfolio(Entities.PortfolioEnt portfolioEnt)
        //{
        //    return new PortfolioDto()
        //    {
        //        Id = portfolioEnt.Id,
        //        Name = portfolioEnt.Name,
        //        //UserId = portfolio.UserId,
        //        Accounts = portfolioEnt.Accounts.Select(e => CreateAccount(e, false)).ToList()
        //    };
        //}

        //public static InvestmentDto CreateInvestment(InvestmentEnt investmentEnt)
        //{
        //    return new InvestmentDto()
        //    {
        //        Id = investmentEnt.ID,
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
    }
}