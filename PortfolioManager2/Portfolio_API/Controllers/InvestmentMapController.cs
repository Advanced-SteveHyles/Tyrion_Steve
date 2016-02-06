using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.Facebook;
using PortfolioManager.DTO;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Entities;
using PortfolioManager.Repository.Factories;

namespace Portfolio_API.Controllers
{
    public class InvestmentMapController : ApiController
    {
        private InvestmentRepository _investmentRepository;
        private AccountRepository _accountRepository;

        public InvestmentMapController()
        {
            _investmentRepository = new InvestmentRepository(new PortfolioManagerContext());
            _accountRepository = new AccountRepository(new PortfolioManagerContext());
        }

        [HttpGet]
        public IHttpActionResult Get(int accountId)
        {
            var map = new AccountInvestmentMapDto();

            var accountEnt = _accountRepository.GetAccount(accountId);
            map.AccountInfo = accountEnt.MapToDto();

            ICollection<Investment> investmentEnt = _investmentRepository.GetInvestments();

            
            

        }

    }
}
