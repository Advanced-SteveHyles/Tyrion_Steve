using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PortfolioManagerWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Link",
                            "AccountInvestmentMapController/LinkAccountToInvestment/{accountId}/{investmentId}",
                            new
                            {
                                controller = "AccountInvestmentMapController",
                                action = "LinkAccountToInvestment",
                                name = UrlParameter.Optional,
                                year = UrlParameter.Optional
                            });
        }
    }
}
