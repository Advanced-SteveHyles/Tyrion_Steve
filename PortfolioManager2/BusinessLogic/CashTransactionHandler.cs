using System;
using Interfaces;
using Portfolio.Constants;
using PortfolioManager.DTO.Requests;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic
{
    public class CashTransactionHandler : ITransactionHandler
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
                          CashTransactionTypes.Deposit
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