
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

        public virtual DbSet <Portfolio> Portfolios { get; set; }
    }
}