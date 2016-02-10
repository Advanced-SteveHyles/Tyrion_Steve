using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreatePriceHistoryTransaction    : ICommandRunner
{
        private readonly PriceHistoryRequest _priceHistoryRequest;
        private readonly IPriceHistoryHandler _priceHistoryHandler;

        public CreatePriceHistoryTransaction(PriceHistoryRequest priceHistoryRequest, IPriceHistoryHandler priceHistoryHandler)
        {
            _priceHistoryRequest = priceHistoryRequest;
            _priceHistoryHandler = priceHistoryHandler;        
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public bool CommandValid { get; }
        public bool ExecuteResult { get; }
}

}
