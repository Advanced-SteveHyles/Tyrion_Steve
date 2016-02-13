using System.Collections.Generic;
using System.Linq;
using Interfaces;
using PortfolioManager.DTO.DTOs;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic
{
    public class AccountInvestmentMapHandler : IAccountInvestmentMapHandler
    {
        private readonly IAccountInvestmentMapRepository  _repository;
        private readonly IPriceHistoryRepository _priceHistoryRepository;

        public AccountInvestmentMapHandler(
            IAccountInvestmentMapRepository repository, 
            IPriceHistoryRepository repository2)
        {
            _repository = repository;
            _priceHistoryRepository = repository2;
        }        

        public void ChangeQuantity(int investmentMapId, decimal quantity)
        {            
            var investmentMap = _repository.GetAccountInvestmentMap(investmentMapId);
            investmentMap.Quantity += quantity;            
            _repository.UpdateAccountInvestmentMap(investmentMap);        
        }

        public decimal RevalueMap(int investmentMapId, decimal? currentSellPrice)
        {
            var investmentMap = _repository.GetAccountInvestmentMap(investmentMapId);

            var valuation = investmentMap.Quantity*currentSellPrice;
            investmentMap.Valuation = valuation ;        
            _repository.UpdateAccountInvestmentMap(investmentMap);

            return valuation ??0;
        }

        public AccountInvestmentMapDto GetAccountInvestmentMap(int investmentMapId)
        {
            return _repository.GetAccountInvestmentMap(investmentMapId).MapToDto();
        }

        public List<AccountInvestmentMapDto> GetMapsByInvestmentId(int investmentId)
        {
            return _repository.GetAccountInvestmentMapsByInvestmentId(investmentId).ToList();
        }
    }
}