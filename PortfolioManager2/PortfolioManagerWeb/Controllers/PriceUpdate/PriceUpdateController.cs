using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PortfolioManager.DTO.DTOs.PriceUpdates;

namespace PortfolioManagerWeb.Controllers.Investments
{
    public class PriceUpdateController : Controller
    {
        public PriceUpdateController()
        {
            var x =1;
        }
        public ActionResult EditPrice(int id)
        {
            var y = new InvestmentPriceUpdate
            {
                InvestmentId = 50,
                InvestmentName = "Happy",
                LatestBuyPrice = (decimal)1.20,
                LatestSellPrice = (decimal)1.09,
                LatestBuyPriceDate = DateTime.Today,
                LatestSellPriceDate = DateTime.Today.AddDays(-4)
            };
            return View(y);
        }

        [HttpPost]
        public async Task<ActionResult> EditPrice(InvestmentPriceUpdate dto)
        {
            return null;
        }
    }
}
