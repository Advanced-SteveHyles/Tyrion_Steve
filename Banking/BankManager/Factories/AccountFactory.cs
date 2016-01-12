using Common.Enums;
using Interfaces;

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
