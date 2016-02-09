using System;
using System.Linq;
using PortfolioManager.Repository.Entities;
using PortfolioManager.Repository.Interfaces;

namespace PortfolioManager.Repository
{
    public class InvestmentRepository : BaseRepository, IInvestmentRepository
    {
        public InvestmentRepository(PortfolioManagerContext context) : base(context)
        {
        }

        public IQueryable<Investment> GetInvestments()
        {
            var investment = _context.Investments;
            return investment;
        }

        public RepositoryActionResult<Investment> InsertInvestment(Investment entityInvestment)
        {
            try
            {
                _context.Investments.Add(entityInvestment);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Investment>(entityInvestment, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Investment>(entityInvestment, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Investment>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }
}