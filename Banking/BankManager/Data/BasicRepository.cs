using Interfaces;
using System;
using System.Linq;

namespace Data
{
   public class BasicRepository : IBasicRepository
    {
       private PortfolioManagerContext _ctx;
       public BasicRepository(PortfolioManagerContext ctx)
        {
            _ctx = ctx;
        }

       //public IQueryable<Accounts.Account> GetAccountsByPortfolioId(int portfolioId) {    return null; }
       //////return _ctx.Accounts.Where(p=>p.AccountType== Common.Enums.EnumAccountType.Test; 
       ////{
       // //    return _ctx.Accounts.Where(p=>p.PortfolioID == portfolioId);            
       // //}

       // public IQueryable<Accounts.Transaction> GetTransactionsByAccountId(int accountID){ return null; }
       // //{
       // //    return _ctx.Transactions.Where(r=>r.AccountId == accountID);   
       // //}

       // public IQueryable<Accounts.Transaction> GetTransactionsByStatementId(int statementId){ return null; }
       // //{
       // //    return _ctx.Transactions.Where(r => r.StatementId == statementId);
       // //}

       // public IQueryable<Accounts.Portfolio> GetPortfolios(){ return null; }
       // //{
       // //    return _ctx.Portfolios;            
       // //}

       // public IQueryable<Accounts.Portfolio> GetPortfolioByPortfolioId(int portfolioId){ return null; }
       // //{
       // //    return _ctx.Portfolios.Where(p => p.PortfolioID == portfolioId);            
       // //}



       public IQueryable<Accounts.Account> GetAccountsByPortfolioId(int portfolioId)
       {
           throw new NotImplementedException();
       }

       public IQueryable<Accounts.Transaction> GetTransactionsByAccountId(int accountId)
       {
           throw new NotImplementedException();
       }

       public IQueryable<Accounts.Transaction> GetTransactionsByStatementId(int statementId)
       {
           throw new NotImplementedException();
       }

       public IQueryable<IPortfolioDTO> GetPortfolios()
       {
           throw new NotImplementedException();
       }

       public IQueryable<IPortfolioDTO> GetPortfolioByPortfolioId(int portfolioId)
       {
           throw new NotImplementedException();
       }
    }
}
