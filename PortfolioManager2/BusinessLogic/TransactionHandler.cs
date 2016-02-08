using System;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;
using PortfolioManager.Repository;

namespace BusinessLogicTests
{
    public class TransactionHandler : ITransactionHandler
    {
        private readonly ITransactionRepository _repository;

        public TransactionHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public void StoreTransaction(DepositTransactionRequest depositTransactionRequest)
        {
            _repository.ApplyCashTransaction
                (
                depositTransactionRequest.AccountId,
                depositTransactionRequest.TransactionDate,
                depositTransactionRequest.Source,
                depositTransactionRequest.Value,
                depositTransactionRequest.IsTaxRefund,
                "Deposit"
                );
        }

        public void StoreTransaction(WithdrawalTransactionRequest withdrawalTransactionRequest)
        {
            _repository.ApplyCashTransaction
                      (
                      withdrawalTransactionRequest.AccountId,
                      withdrawalTransactionRequest.TransactionDate,
                      withdrawalTransactionRequest.Source,
                      withdrawalTransactionRequest.Value,
                      false,
                      "Withdrawal",
                      new CashTransactionRequest(withdrawalTransactionRequest),
                      );
        }

        public void StoreTransaction(int accountId, InvestmentBuyRequest investmentBuyRequest)
        {
            var depositTransaction = new DepositTransactionRequest()
            {
                AccountId = accountId,
                TransactionDate = investmentBuyRequest.PurchaseDate,
                Value = investmentBuyRequest.Value,
                Source = "Buy",
                IsTaxRefund = false,
            };

            StoreTransaction(depositTransaction);
        }
    }

    internal class CashTransactionRequest
    {
        public int AccountId;
        public DateTime TransactionDate;
        public decimal Value;
        public string Source;
        public string IsTaxRefund ;

        public CashTransactionRequest()
        {
                    public int AccountId;
        public DateTime TransactionDate;
        public decimal Value;
        public string Source;
        public string IsTaxRefund;
    }
    }
}