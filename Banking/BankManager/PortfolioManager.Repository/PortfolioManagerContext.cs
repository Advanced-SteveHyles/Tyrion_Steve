
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository
{
    public class PortfolioManagerContext :DbContext
    {
        public PortfolioManagerContext():base ("name=PortfolioManagerContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<PortfolioManagerContext>(null);
        }

        public DbSet<DBGenerator> DBGenerator { get; set; }

        public virtual DbSet<Portfolio> Portfolios { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Investment> Investments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>()
                .HasMany(e => e.Accounts);
        }
    }

    public class DBGenerator
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VersionID { get; set; }
    }
}