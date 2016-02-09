using Interfaces;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic
{
    public class AccountInvestmentMapHandler : IAccountInvestmentMapHandler
    {
        private readonly IAccountInvestmentMapRepository  _repository;

        public AccountInvestmentMapHandler(IAccountInvestmentMapRepository repository)
        {
            _repository = repository;
        }        

        public void UpdateMapQuantity(int investmentMapId, decimal quantity)
        {            
            var investmentMap = _repository.GetAccountInvestmentMap(investmentMapId);
            investmentMap.Quantity += quantity;            
            _repository.UpdateAccountInvestmentMap(investmentMap);

            //    public int Quantity { get; set; }
            //public int SellPrice { get; set; }
            //public int Valuation { get; set; }
            //public DateTime LastValuationDate { get; set; }
        }
    }
}