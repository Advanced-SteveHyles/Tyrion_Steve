﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Interfaces;
using Newtonsoft.Json;
using PortfolioManager.DTO.Transactions;

namespace PortfolioManagerWeb.Controllers
{
    public class InvestmentsMapController : Controller
    {

        public ActionResult Buy(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Buy(int mapId, InvestmentBuyRequest buy)
        {
            try
            {
                buy.MapId = mapId;

                var response = await ProcessBuyTransaction(buy);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Accounts", new { id = 1 });
                }
                else
                {
                    return Content("An error occurred");
                }
            }
            catch
            {
                return Content("An error occurred");
            }
        }

        private static async Task<HttpResponseMessage> ProcessBuyTransaction(InvestmentBuyRequest buy)
        {
            var client = PortfolioManagerHttpClient.GetClient();

            var serializedItemToCreate = JsonConvert.SerializeObject(buy);

            var response = await client.PostAsync(ApiPaths.BuyTransaction,
                new StringContent(serializedItemToCreate,
                    System.Text.Encoding.Unicode, "application/json"));
            return response;
        }

        public ActionResult Sell(int id)
        {
            return View();
        }


        public async Task<ActionResult> Dividend(int id)
        {
            return View();
        }


        public async Task<ActionResult> CorporateAction(int id)
        {
            return View();
        }

        public async Task<ActionResult> Resolves()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult> Resolve(object id)
        {
            throw new System.NotImplementedException();
        }
    }

    
}