using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Interfaces;
using PortfolioManager.DTO;
using PortfolioManager.DTO.DTOs;
using PortfolioManager.DTO.Requests;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Factories;

namespace Portfolio_API.Controllers
{
    public class AccountInvestmentMapController : ApiController
    {
        private readonly InvestmentRepository _investmentRepository;
        private readonly AccountRepository _accountRepository;

        public AccountInvestmentMapController()
        {
            _investmentRepository = new InvestmentRepository(new PortfolioManagerContext());
            _accountRepository = new AccountRepository(new PortfolioManagerContext());
        }

        public IHttpActionResult Get(int id)
        {
            var map = new AccountInvestmentMapDto();

            var accountEnt = _accountRepository.GetAccount(id);
            map.AccountInfo = accountEnt.MapToDto();

            var investmentEntities = _investmentRepository.GetInvestments();
            map.Investments = new List<InvestmentDto>();
            foreach (var investment in investmentEntities.ToList())
            {
                map.Investments.Add(investment.MapToDto());
            }

            try
            {
                //return Ok(ShapedData.CreateDataShapedObject(accountEnt, lstOfFields));
                return Ok(map);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return BadRequest();
            }
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route(ApiPaths.InvestmentMap)]
        public IHttpActionResult Post([FromBody] AccountInvestmentMapRequest investmentMapRequest)
        {
            try
            {
                if (investmentMapRequest == null)
                {
                    return BadRequest();
                }

                var entityInvestmentMap = InvestmentMapFactory.CreateInvestmentMap(investmentMapRequest);
                if (entityInvestmentMap == null)
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

                var result = _accountRepository.InsertInvestmentMap(entityInvestmentMap);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    var dtoInvestment = result.Entity.MapToDto();
                    return Created(Request.RequestUri + "/" + dtoInvestment.InvestmentId, dtoInvestment);
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
