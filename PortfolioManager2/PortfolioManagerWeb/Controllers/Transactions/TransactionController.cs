using System.Web.Mvc;

namespace PortfolioManagerWeb.Controllers
{
    public class TransactionController : Controller
    {
        public ActionResult TransactionSummary(int accountid)
        {
            return View();
        }
    }
}