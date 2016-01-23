using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Portfolio_API.Controllers
{
    public class AccountsController : ApiController
    {
        public IHttpActionResult Get(int id, string fields = null)
        {
            try
            {
                bool includeInvestments = false;
                List<string> lstOfFields = new List<string>();

                // we should include expenses when the fields-string contains "expenses"
                if (fields != null)
                {
                    lstOfFields = fields.ToLower().Split(',').ToList();
                    includeInvestments = lstOfFields.Any(f => f.Contains("investments"));
                }

                Entities.AccountEnt accountEnt;
                if (includeInvestments)
                {
                    accountEnt = FakeData.GetAccountWithInvestments(id);
                }
                else
                {
                    accountEnt = FakeData.GetAccount(id);
                }

                var result = FakeData.GetAccount(id);

                if (result != null)
                {

                    return Ok(ShapedData.CreateDataShapedObject(accountEnt, lstOfFields));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

    }
}
