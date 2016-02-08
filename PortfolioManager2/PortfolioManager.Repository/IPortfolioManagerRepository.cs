using System.Linq;
using PortfolioManager.Repository.Entities;
using PortfolioManager.DTO.Requests;

namespace PortfolioManager.Repository
{
    public interface ITransactionRepository
    {
        RepositoryActionResult<CashTransaction> ApplyCashTransaction(CreateCashTransactionRequest request);
    }

    public interface IInvestmentMapRepository
    {        
        InvestmentMap GetInvestmentMap(int investmentMapId);
        void Save(InvestmentMap investmentMap);
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
