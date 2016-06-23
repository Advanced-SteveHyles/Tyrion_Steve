using DebtsModel.DTO;
using GraphQL.Types;

namespace DebtsModel.GraphQLDTO
{
    public class DebtType : ObjectGraphType
    {
        public DebtType()
        {
            Name = "Debt";
            Description = "A debt";
            
            Field<DecimalGraphType>("originalDebt", "The original balance of the debt");
            Field<StringGraphType>("claimNumber", "The claim number");
            //Field<StringGraphType>("currentMilestone", "The Current Milestone");
            Field<StringGraphType>("dateOfService", "");
            Field<DecimalGraphType>("totalCosts", "TotalCosts");
            Field<DecimalGraphType>("interest", "Interest");
            Field<DecimalGraphType>("disbursements", "Disbursements / Total Fees");
            Field<DecimalGraphType>("paidToDate", "Paid To Date");
            Field<DecimalGraphType>("currentBalance", "Current Balance / Summary Balance");

            IsTypeOf = value => value is Debt;
        }
    }
}