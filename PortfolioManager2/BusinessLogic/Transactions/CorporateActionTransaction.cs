using System;
using BusinessLogic.Validators;
using Interfaces;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class CorporateActionTransaction: ICommandRunner
    {
        private readonly CorporateActionRequest _request;
        private readonly FundTransactionHandler _fundTransactionHandler;
        private readonly ICashTransactionHandler _cashTransactionHandler;
        private readonly AccountInvestmentMapHandler _accountInvestmentMapHandler;

        public CorporateActionTransaction(CorporateActionRequest request, FundTransactionHandler fundTransactionHandler, ICashTransactionHandler cashTransactionHandler, AccountInvestmentMapHandler accountInvestmentMapHandler)
        {
            _request = request;
            _fundTransactionHandler = fundTransactionHandler;
            _cashTransactionHandler = cashTransactionHandler;
            _accountInvestmentMapHandler = accountInvestmentMapHandler;
        }

        public void Execute()
        {
         //   var investmentMapDto = _accountInvestmentMapHandler.GetAccountInvestmentMap(_fundBuyRequest.InvestmentMapId);
        //    var investmentId = investmentMapDto.InvestmentId;
       //     var accountId = investmentMapDto.AccountId;

            _fundTransactionHandler.StoreFundTransaction(_request);

       //     _cashTransactionHandler.StoreCashTransaction(accountId, _request);
        }

        public bool CommandValid => _request.Validate();
        public bool ExecuteResult { get; }
    }
}