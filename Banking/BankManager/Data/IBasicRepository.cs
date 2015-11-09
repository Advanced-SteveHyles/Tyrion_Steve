using Data.Accounts;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    //Only add things when they are needed.
    [Obsolete]
    public interface IBasicRepository
    {
        IQueryable<Account> GetAccountsByPortfolioId(int portfolioId);
        IQueryable<Transaction> GetTransactionsByAccountId(int accountId);
        IQueryable<Transaction> GetTransactionsByStatementId(int statementId);

        IQueryable<IPortfolioDTO> GetPortfolios();
        IQueryable<IPortfolioDTO> GetPortfolioByPortfolioId(int portfolioId);

    }
}
