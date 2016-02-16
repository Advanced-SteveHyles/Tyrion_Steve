﻿using System.Collections.Generic;
using System.Linq;
using Interfaces;
using PortfolioManager.DTO.DTOs;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic
{
    public class AccountInvestmentMapHandler : IAccountInvestmentMapHandler
    {
        private readonly IAccountInvestmentMapRepository  _accountInvestmentMapRepository;

        public AccountInvestmentMapHandler(
            IAccountInvestmentMapRepository accountInvestmentMapRepository)
        {
            _accountInvestmentMapRepository = accountInvestmentMapRepository;
        }        

        public void ChangeQuantity(int investmentMapId, decimal quantity)
        {            
            var investmentMap = _accountInvestmentMapRepository.GetAccountInvestmentMap(investmentMapId);
            investmentMap.Quantity += quantity;            
            _accountInvestmentMapRepository.UpdateAccountInvestmentMap(investmentMap);        
        }

        public decimal RevalueMap(int investmentMapId, decimal? currentSellPrice)
        {
            var investmentMap = _accountInvestmentMapRepository.GetAccountInvestmentMap(investmentMapId);

            var valuation = investmentMap.Quantity*currentSellPrice;
            investmentMap.Valuation = valuation ;        
            _accountInvestmentMapRepository.UpdateAccountInvestmentMap(investmentMap);

            return valuation ??0;
        }

        public AccountInvestmentMapDto GetAccountInvestmentMap(int investmentMapId)
        {
            return _accountInvestmentMapRepository.GetAccountInvestmentMap(investmentMapId).MapToDto();
        }

        public List<AccountInvestmentMapDto> GetMapsByInvestmentId(int investmentId)
        {
            return _accountInvestmentMapRepository
                    .GetAccountInvestmentMapsByInvestmentId(investmentId)
                    .Select(aiv => aiv.MapToDto())
                    .ToList();
        }

        public List<AccountInvestmentMapDto> GetMapsByAccountId(int accountId)
        {
            return _accountInvestmentMapRepository.GetAccountInvestmentMaps()
                .Where(map => map.AccountId == accountId)
                .Select(map=>map.MapToDto())
                .ToList();
        }
    }
}