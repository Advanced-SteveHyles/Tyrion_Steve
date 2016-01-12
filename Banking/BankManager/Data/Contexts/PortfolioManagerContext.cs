using Data.Accounts;
using Data.Ref;
using Interfaces.Data.Contexts;
using System.Data.Entity;

namespace Data 
{
    public class PortfolioManagerContext : DbContext, IPortfolioManagerContext
    {
        public PortfolioManagerContext()
            : base("Data Source=(localdb)\\ProjectsV12;Initial Catalog=PortfolioManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<PortfolioManagerContext, BankmangerMigrationsConfiguration>());
        }

        public DbSet<DBGenerator> DBGenerator { get; set; }

        //Reference Types
         //public DbSet<TransactionType> TransactionTypes { get; set; }
         //public DbSet<AccountType> AccountTyes { get; set; }
        
        //Entities
        internal DbSet<Transaction> Transactions { get; set; }
        internal DbSet<Account> Accounts { get; set; }
        internal DbSet<Statement> Statements { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }
                   
    }
}
