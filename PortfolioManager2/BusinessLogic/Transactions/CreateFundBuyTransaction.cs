using Interfaces;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateFundBuyTransaction : ICommandRunner
    {
        private readonly int _accountId;
        private readonly InvestmentBuyRequest _fundBuyRequest;
        private readonly IAccountHandler _accountHandler;
        private readonly ITransactionHandler _transactionHandler;
        private readonly IAccountInvestmentMapHandler _accountInvestmentMapHandler;
        private IFundTransactionHandler _fundTransactionHandler;

        public CreateFundBuyTransaction(int accountId,
            InvestmentBuyRequest fundBuyRequest, 
            IAccountHandler accountHandler, 
            ITransactionHandler transactionHandler,
            IAccountInvestmentMapHandler accountInvestmentMapHandler,
            IFundTransactionHandler fundTransactionHandler)
        {
            _accountId = accountId;
            _fundBuyRequest = fundBuyRequest;
            _accountHandler = accountHandler;
            _transactionHandler = transactionHandler;
            _accountInvestmentMapHandler = accountInvestmentMapHandler;
            _fundTransactionHandler = fundTransactionHandler;
        }

        public void Execute()
        {
            _fundTransactionHandler.StoreFundTransaction(_fundBuyRequest);

            _transactionHandler.StoreCashTransaction(_accountId, _fundBuyRequest);

            _accountHandler.DecreaseAccountBalance(_accountId, _fundBuyRequest.Value);

            _accountInvestmentMapHandler.ChangeQuantity(_fundBuyRequest.InvestmentMapId, _fundBuyRequest.Quantity);
            //_accountInvestmentMapHandler.RevalueMap(_fundBuyRequest.InvestmentMapId);
            
            ExecuteResult = true;
        }

        public bool CommandValid => 
            _fundBuyRequest.InvestmentMapId != 0 && 
            _accountId != 0
            ;


        public bool ExecuteResult { get; private set; }
        
    }
}
