using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogic
{
    public class CreateDepositTransaction : ICommandRunner
    {
        private DepositTransactionRequest depositTransactionRequest;

        public CreateDepositTransaction(DepositTransactionRequest depositTransactionRequest)
        {
            this.depositTransactionRequest = depositTransactionRequest;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public bool CommandValid()
        {
            throw new NotImplementedException();
        }
    }
}
