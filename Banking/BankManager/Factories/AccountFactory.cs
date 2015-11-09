using Common.Enums;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
  public static class AccountFactory
    {
      public static IAccount CreateAccount(EnumAccountType AccountType)
        {
            IAccount NewAccount = null;
            switch (AccountType)
            {
                default:
                   NewAccount = new Data.Accounts.Account();
                    break;
            }

            return NewAccount;
        }
    }
}
