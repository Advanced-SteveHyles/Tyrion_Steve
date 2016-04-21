using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DEMO.Models;

namespace MVC_DEMO.Controllers
{
    public class SteveController : Controller
    {
        // GET: Steve
        public ActionResult Index()
        {
            var model = list;
            return View(model);
        }

        List<StevesFirstData> list = new List<StevesFirstData>()
        {
            {
                new StevesFirstData("Steve")
            },
            {
                new StevesFirstData("Not Steve")
            },
        };

    }
}