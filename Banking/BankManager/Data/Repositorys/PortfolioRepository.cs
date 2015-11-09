using Common.DTOs;
using Data.Accounts;
using Interfaces;
using Interfaces.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorys
{

    //https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application

    public class PortfolioRepository : IPortfolioRepository
    {
        private PortfolioManagerContext _ctx;
        //private IPortfolioManagerContext _ctx;
        public PortfolioRepository(IPortfolioManagerContext ctx)
        {
            _ctx =(PortfolioManagerContext) ctx;
            
        }

        public IQueryable<IPortfolioDTO> GetAllPortfolios()
        {
            //using (_ctx)
            //{
            var x = _ctx.Portfolios.Select(p => new PortfolioDTO() { PortfolioID=p.PortfolioID, PortfolioName = p.PortfolioName });
                return x;
            //}                       

        //    return port.ToList();
        }

        public void Save(string portfolioName)
        {
            var p = new Portfolio();
            _ctx.Portfolios.Add(p);

            p.PortfolioName = portfolioName;

            _ctx.SaveChanges();
        }

        public void Save(int portfolioId, string portfolioName)
        {
            var dto =Find(portfolioId);
            //Change object
            dto.PortfolioName = portfolioName;
            //??
            _ctx.SaveChanges();
        }


        IPortfolioDTO Find(int portfolioId)
        {
            var x = _ctx.Portfolios.Where(p=>p.PortfolioID == portfolioId);
           // return x.SingleOrDefault();
            return null;
        }


    }
}
