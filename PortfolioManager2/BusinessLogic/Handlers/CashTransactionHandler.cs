using System;
using Interfaces;
using PortfolioManager.Constants.TransactionTypes;
using PortfolioManager.DTO.Requests;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic
{
    public class CashTransactionHandler : ICashTransactionHandler
    {
        private readonly ICashTransactionRepository _repository;

        public CashTransactionHandler(ICashTransactionRepository repository)
        {
            _repository = repository;
        }

        public void StoreCashTransaction(DepositTransactionRequest depositTransactionRequest)
        {
            StoreCashTransaction(
                depositTransactionRequest.AccountId,
                depositTransactionRequest.TransactionDate,
                depositTransactionRequest.Source,
                depositTransactionRequest.Value,
                depositTransactionRequest.IsTaxRefund,
                 CashTransactionTypes.Deposit
                );            
        }

        public void StoreCashTransaction(WithdrawalTransactionRequest withdrawalTransactionRequest)
        {
            StoreCashTransaction(
                      withdrawalTransactionRequest.AccountId,
                      withdrawalTransactionRequest.TransactionDate,
                      withdrawalTransactionRequest.Source,
                      withdrawalTransactionRequest.Value,
                      false,
                  CashTransactionTypes.Withdrawal
                      );
        }

        public void StoreCashTransaction(int accountId, InvestmentBuyRequest investmentBuyRequest)
        {
            var source = string.Empty;       
            StoreCashTransaction(
                          accountId,
                          investmentBuyRequest.PurchaseDate,
                          source,
                          investmentBuyRequest.Value,
                          false,
                          CashTransactionTypes.FundPurchase
                          );
        }

        public void StoreCashTransaction(int accountId, CorporateActionRequest corporateActionRequest)
        {
            var source = string.Empty;
            StoreCashTransaction(
                          accountId,
                          corporateActionRequest.TransactionDate,
                          source,
                          corporateActionRequest.Amount,
                          false,
                          CashTransactionTypes.CorporateAction
                          );
        }

        private void StoreCashTransaction(int accountId, DateTime transactionDate, string source, decimal value, bool isTaxRefund, string transactionType )
        {
            var cashTransaction = new CreateCashTransactionRequest()
            {
                AccountId = accountId,
                TransactionDate = transactionDate,
                TransactionType = transactionType,
                TransactionValue = value,
                Source = source,
                IsTaxRefund = isTaxRefund,
            };

            _repository.InsertCashTransaction(cashTransaction);        
        }
    }

  
}