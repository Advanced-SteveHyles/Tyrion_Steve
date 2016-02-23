using System;
using BusinessLogic.Handlers;
using BusinessLogic.Validators;
using Interfaces;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class CorporateActionTransaction: ICommandRunner
    {
        private readonly CorporateActionRequest _request;
        private readonly IFundTransactionProcessor _fundTransactionProcessor;
        private readonly ICashTransactionProcessor _cashTransactionProcessor;
        private readonly IAccountInvestmentMapProcessor _accountInvestmentMapProcessor;

        public CorporateActionTransaction(CorporateActionRequest request, IFundTransactionProcessor fundTransactionProcessor, ICashTransactionProcessor cashTransactionProcessor, IAccountInvestmentMapProcessor accountInvestmentMapProcessor)
        {
            _request = request;
            _fundTransactionProcessor = fundTransactionProcessor;
            _cashTransactionProcessor = cashTransactionProcessor;
            _accountInvestmentMapProcessor = accountInvestmentMapProcessor;
        }

        public void Execute()
        {
            var investmentMapDto = _accountInvestmentMapProcessor.GetAccountInvestmentMap(_request.InvestmentMapId);
            var investmentId = investmentMapDto.InvestmentId;
            var accountId = investmentMapDto.AccountId;

            _fundTransactionProcessor.StoreFundTransaction(_request);
            _cashTransactionProcessor.StoreCashTransaction(accountId, _request);
        }

        public bool CommandValid => _request.Validate();
        public bool ExecuteResult { get; }
    }
}