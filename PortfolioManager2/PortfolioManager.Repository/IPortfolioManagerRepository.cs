using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.DTO;
using PortfolioManager.DTO.DTOs.Transactions;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository
{
    public interface ITransactionRepository
    {
        RepositoryActionResult<CashTransaction> ApplyCashTransaction(int accountId, DateTime transactionDate, string source, decimal value, bool isTaxRefund, string transactionType);
    }

    public interface IAccountRepository
    {
        RepositoryActionResult<Account> InsertAccount(Account entityAccount);
        Account GetAccountWithInvestments(int id);
        Account GetAccount(int id);

        void IncreaseAccountBalance(int accountId, decimal amount);
        void DecreaseAccountBalance(int accountId, decimal amount);

        IQueryable<CashTransaction> GetAccountTransactions(int accountId);
    }

    public interface IInvestmentRepository
    {
        RepositoryActionResult<Investment> InsertInvestment(Investment entityInvestment);

        System.Linq.IQueryable<Entities.Investment> GetInvestments();
    }

    public interface IPortfolioRepository
    {
        System.Linq.IQueryable<Entities.Portfolio> GetPortfolios();

        Portfolio GetPortfolio(int id);
        Portfolio GetPortfolioWithAccounts(int id);
        RepositoryActionResult<Portfolio> InsertPortfolio(Portfolio entityPortfolio);
    }
}
