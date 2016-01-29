using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpenseTracker.Repository;
using PortfolioManager.DTO;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Factories;

namespace Portfolio_API.Controllers
{
    public class AccountsController : ApiController
    {
        IPortfolioManagerRepository _repository;

        public AccountsController()
        {
            _repository = new PortfolioManagerEfRepository(new PortfolioManagerContext());
        }

        //public IHttpActionResult Get(int id, string fields = null)
        //{
        //    try
        //    {
        //        bool includeInvestments = false;
        //        List<string> lstOfFields = new List<string>();

        //        // we should include expenses when the fields-string contains "expenses"
        //        if (fields != null)
        //        {
        //            lstOfFields = fields.ToLower().Split(',').ToList();
        //            includeInvestments = lstOfFields.Any(f => f.Contains("investments"));
        //        }

        //        Entities.AccountEnt accountEnt;
        //        if (includeInvestments)
        //        {
        //            accountEnt = FakeData.GetAccountWithInvestments(id);
        //        }
        //        else
        //        {
        //            accountEnt = FakeData.GetAccount(id);
        //        }

        //        var result = FakeData.GetAccount(id);

        //        if (result != null)
        //        {

        //            return Ok(ShapedData.CreateDataShapedObject(accountEnt, lstOfFields));
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError();
        //    }
        //}

        [System.Web.Http.HttpPost]
        [Route("api/accounts")]
        public IHttpActionResult Post([FromBody] AccountRequest account)
        {
            try
            {
                if (account == null)
                {
                    return BadRequest();
                }

                var entityAccount   = new AccountFactory().CreateAccount(account);
                if (entityAccount == null)
                {
                    return BadRequest();
                }

                /*
                {
                    "userId": "https://expensetrackeridsrv3/embedded_1",
                    "title": "STV",
                    "description": "STV",
                    "expenseGroupStatusId": 1,
                }
                */

                var result = _repository.InsertAccount(entityAccount);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    var dtoAccount = EntityToDtoMap.MapAccountToDto(result.Entity);
                    return Created(Request.RequestUri + "/" + dtoAccount.Id, dtoAccount);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return InternalServerError();
            }
        }




    }
}
