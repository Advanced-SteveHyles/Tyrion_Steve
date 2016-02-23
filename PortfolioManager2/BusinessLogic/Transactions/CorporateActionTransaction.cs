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
        private readonly IInvestmentProcessor _investmentProcessor;

        public CorporateActionTransaction(CorporateActionRequest request, IFundTransactionProcessor fundTransactionProcessor, ICashTransactionProcessor cashTransactionProcessor, IAccountInvestmentMapProcessor accountInvestmentMapProcessor, IInvestmentProcessor investmentProcessor)
        {
            _request = request;
            _fundTransactionProcessor = fundTransactionProcessor;
            _cashTransactionProcessor = cashTransactionProcessor;
            _accountInvestmentMapProcessor = accountInvestmentMapProcessor;
            _investmentProcessor = investmentProcessor;
        }

        public void Execute()
        {
            var investmentMapDto = _accountInvestmentMapProcessor.GetAccountInvestmentMap(_request.InvestmentMapId);
            var investmentId = investmentMapDto.InvestmentId;
            var accountId = investmentMapDto.AccountId;

            var investment = _investmentProcessor.GetInvestment(investmentId);

            _fundTransactionProcessor.StoreFundTransaction(_request);

            if (investment.Class == PortfolioManager.Constants.Funds.FundClasses.Oeic)
            { 
                _cashTransactionProcessor.StoreCashTransaction(accountId, _request);
            }
        }

        public bool CommandValid => _request.Validate();
        public bool ExecuteResult { get; }
    }
}

