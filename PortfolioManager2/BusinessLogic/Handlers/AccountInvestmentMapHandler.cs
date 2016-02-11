using System.Collections.Generic;
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

            //    public int Quantity { get; set; }
            //public int SellPrice { get; set; }
            //public int Valuation { get; set; }
            //public DateTime LastValuationDate { get; set; }
        }

        public decimal RevalueMap(int investmentMapId, decimal? currentSellPrice)
        {
            throw new System.NotImplementedException();
        }

        public AccountInvestmentMapDto GetAccountInvestmentMap(int investmentMapId)
        {
            throw new System.NotImplementedException();
        }

        public List<AccountInvestmentMapDto> GetMapsByInvestmentId(int investmentId)
        {
            throw new System.NotImplementedException();
        }
    }
}