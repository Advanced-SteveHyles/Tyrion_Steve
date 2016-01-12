using System.Linq;
using System.Data.Entity.Migrations;

namespace Data
{
    public class BankmangerMigrationsConfiguration : DbMigrationsConfiguration<PortfolioManagerContext>
    {
        public BankmangerMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;  // Deletes field if not longer used
            this.AutomaticMigrationsEnabled = true; // Allows fixing
                    }

        protected override void Seed(PortfolioManagerContext context)
        {
            //Seed called everytime application restarts
            //Allows seeding
            base.Seed(context);

            if (context.Portfolios.Count() == 0)
            {
                //Allow seeding

            }

            //foreach (var ea in Enum.GetValues(typeof(EnumAccountType)))
            //{
            //    EnumToTableFactory.CreateAccountTypeTable(context, (EnumAccountType)ea);
            //}

            //foreach (var ea in Enum.GetValues(typeof(EnumTransactionType)))
            //{
            //    EnumToTableFactory.CreateTransactionTypeTable(context, (EnumTransactionType)ea);
            //}

        }
    }
}
