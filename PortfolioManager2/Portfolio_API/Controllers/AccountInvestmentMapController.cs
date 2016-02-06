using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Interfaces;
using Microsoft.Owin.Security.Facebook;
using PortfolioManager.DTO;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Entities;
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

    }
}
