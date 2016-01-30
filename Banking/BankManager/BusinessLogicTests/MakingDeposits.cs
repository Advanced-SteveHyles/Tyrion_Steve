using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PortfolioManager.DTO.Requests.Transactions;
using Xunit;
using BusinessLogic;
using Interfaces;

namespace BusinessLogicTests
{
    public class MakingDeposits
    {
        public class GivenIAmDepositingTenPounds
        {
            private ICommandRunner _depositTransaction;

            public GivenIAmDepositingTenPounds()
            {
                var depositTransactionRequest = new DepositTransactionRequest(1, 10);

                _depositTransaction = new CreateDepositTransaction(depositTransactionRequest);
            }


            [Fact]
            public void WhenTheTransactionCompletesThereIsARecordOfTheDeposit()
            {
                _depositTransaction.Execute();

                Assert.Equal("This is a valid test", "Are you kidding me?");
            }
        }
    }
    
}
