
using System.Data.Entity;
using System.Linq;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository
{
    public class PortfolioManagerContext :DbContext
    {
        public PortfolioManagerContext():base ("name=PortfolioManagerContext")
        {
            
        }

        public virtual DbSet <Portfolio> Portfolios { get; set; }
    }
}