using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PortfolioManager.DTO.DTOs.PriceUpdates;

namespace PortfolioManagerWeb.Controllers.Investments
{
    public class PriceUpdateController : Controller
    {

        public ActionResult PriceUpdateList()
        {
            var x = new InvestmentPriceUpdateList();
            var y = new InvestmentPriceUpdate
            {
                InvestmentId = 50,
                InvestmentName = "Happy",
                LatestBuyPrice = (decimal)1.20,
                LatestSellPrice = (decimal)1.09,
                LatestBuyPriceDate = DateTime.Today,
                LatestSellPriceDate = DateTime.Today.AddDays(-4)
            };
            x.Investments.Add(y);

            y = new InvestmentPriceUpdate
            {
                InvestmentId = 51,
                InvestmentName = "Happy X",
                LatestBuyPrice = (decimal)1.20,
                LatestSellPrice = (decimal)1.09,
                LatestBuyPriceDate = DateTime.Today,
                LatestSellPriceDate = DateTime.Today.AddDays(-4)
            };
            x.Investments.Add(y);

            y = new InvestmentPriceUpdate
            {
                InvestmentId = 52,
                InvestmentName = "Happy Z",
                LatestBuyPrice = (decimal)1.20,
                LatestSellPrice = (decimal)1.09,
                LatestBuyPriceDate = DateTime.Today,
                LatestSellPriceDate = DateTime.Today.AddDays(-4)
            };

            x.Investments.Add(y);

            return View(x);
        }

        //public Task<ActionResult> PriceUpdate(int investmentId, )
        //{
        //    return null;
        //}

        
        public Task<ActionResult> PriceUpdate(int investmentId , string buyAt , string sellAt)
        {
            return null;
        }
    }
}
