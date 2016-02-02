using System;
using System.Collections.Generic;

namespace PortfolioManager.DTO.DTOs.Transactions
{
    public class AccountTransactionSummaryDto
    {
        public int AccountId => 1;

        public ICollection<TransactionDto> Transactions = new List<TransactionDto>()
        {
            {
                new TransactionDto()
                {
                     TransactionId = 1,
        AccountId =1,
        TransactionType = "Fish",
        TransactionDate =DateTime.Now,
        Source ="Somewhere",
        Value = (decimal) 10.00,
        IsTaxRefund = false
    }
            }
        };

    }
}