using System;
using Interfaces;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class CorporateActionTransaction: ICommandRunner
    {
        private readonly CorporateActionRequest _request;

        public CorporateActionTransaction(CorporateActionRequest request)
        {
            _request = request;            
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public bool CommandValid => _request.Validate();
        public bool ExecuteResult { get; }
    }
}