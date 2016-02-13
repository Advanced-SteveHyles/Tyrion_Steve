using System;
using System.Collections.Generic;
using PortfolioManager.DTO;
using PortfolioManager.DTO.DTOs;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;
using PortfolioManager.Repository.Entities;

namespace Interfaces
{
    public interface IAccountHandler
    {
        void IncreaseAccountBalance(int accountId, decimal amount);
        void DecreaseAccountBalance(int accountId, decimal amount);
        void UpdateValuation(int accountId, decimal mapValue);
        Account GetAccount(int accountId);
    }

    public interface ITransactionHandler
    {
        void StoreCashTransaction(DepositTransactionRequest depositTransactionRequest);
        void StoreCashTransaction(WithdrawalTransactionRequest withdrawalTransactionRequest);
        void StoreCashTransaction(int accountId, InvestmentBuyRequest investmentBuyRequest);
    }

    public interface IFundTransactionHandler
    {
        void StoreFundTransaction(InvestmentBuyRequest fundBuyRequest);
    }

    public interface IAccountInvestmentMapHandler
    {
        void ChangeQuantity(int investmentMapId, decimal quantity);
        decimal RevalueMap(int investmentMapId, decimal? currentSellPrice);
        AccountInvestmentMapDto GetAccountInvestmentMap(int investmentMapId);
        List<AccountInvestmentMapDto> GetMapsByInvestmentId(int investmentId);
    }

    public interface IPriceHistoryHandler
{
        void StorePriceHistory(PriceHistoryRequest priceHistoryRequest);
        decimal? GetInvestmentSellPrice(int investmentId, DateTime valuationDate);
        decimal? GetInvestmentBuyPrice(int investmentId, DateTime valuationDate);
}

    public interface IInvestmentHandler
    {
        InvestmentDto GetInvestment(int investmentId);
    }

}
