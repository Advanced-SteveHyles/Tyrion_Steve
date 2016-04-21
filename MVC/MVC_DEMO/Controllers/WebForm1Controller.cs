using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DEMO.Controllers
{
    public class WebForm1 : Controller
    {
        // GET: NotSteve
        public ActionResult Index()
        {
            return View();
        }
    }
}