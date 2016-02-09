using System;
using Interfaces;
using PortfolioManager.Constants.TransactionTypes;
using PortfolioManager.DTO.Requests;
using PortfolioManager.DTO.Transactions;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic
{
    public class FundTransactionHandler : IFundTransactionHandler
    {
        private IFundTransactionRepository _repository;

        public FundTransactionHandler(IFundTransactionRepository repository)
        {
            _repository = repository;
        }

        public void StoreFundTransaction(InvestmentBuyRequest fundBuyRequest)
        {
            int? sellPrice =null;
            var source = string.Empty;
            
            StoreFundTransaction(
                fundBuyRequest.InvestmentMapId,
                fundBuyRequest.PurchaseDate,
                fundBuyRequest.SettlementDate,
                source,
                fundBuyRequest.Value,
                fundBuyRequest.Quantity,
                sellPrice,
                fundBuyRequest.Price,
                fundBuyRequest.Charges,
                FundTransactionTypes.Buy);
        }

        private void StoreFundTransaction(
            int investmentMapId,
            DateTime transactionDate,
            DateTime settlementDate,
            string source,
            decimal transactionValue,
            decimal quantity,
            decimal? sellPrice,
            decimal? buyPrice,
            decimal charges,            
            string transactionType)
        {
            var fundTransaction = new CreateFundTransactionRequest()
            {

                InvestmentMapId = investmentMapId,
                TransactionType = transactionType,
                TransactionDate = transactionDate,
                SettlementDate = settlementDate,
                Source = source,
                Quantity = quantity,
                SellPrice = sellPrice,
                BuyPrice = buyPrice,
                Charges = charges,
                TransactionValue = transactionValue,                
            };

            _repository.InsertFundTransaction(fundTransaction);
        }
    }
}