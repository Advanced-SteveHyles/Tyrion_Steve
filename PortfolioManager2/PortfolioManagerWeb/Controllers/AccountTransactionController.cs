using System.Web.Mvc;

namespace PortfolioManagerWeb.Controllers
{
    public class AccountTransactionController : Controller
    {
        
        public ActionResult DepositFunds(int accountid)
        {
            return View();
        }
    }
}