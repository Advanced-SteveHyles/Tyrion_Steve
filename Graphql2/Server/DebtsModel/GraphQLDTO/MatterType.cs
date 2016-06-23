using System;
using System.Collections.Generic;
using System.Linq;
using DebtsModel.DTO;
using GraphQL.Language;
using GraphQL.Types;

namespace DebtsModel.GraphQLDTO
{
    public class MatterType : ObjectGraphType
    {
        public MatterType(ALBData data)
        {
            Name = "Matter";
            Description = "A legal thingy";

            Field<NonNullGraphType<StringGraphType>>("reference", "The reference of the matter.");
            Field<StringGraphType>("description", "The description of the matter.");
            Field<StringGraphType>("ourReference", "Our reference");

            Field<DateGraphType>("openDate", "Date the matter was opened.");
                        
            Field<FeeEarnerType>("feeEarner", "Fee Earner on the matter",
                   resolve:
                    context =>
                        data.GetFeeEarnerForMatter(context.Source as Matter));

            Field<SupervisorType>("supervisor", "Supervisor on the matter",
                   resolve:
                    context =>
                        data.GetSupervisorForMatter(context.Source as Matter));
            
            Field<ListGraphType<MilestoneType>>("milestones", "the current milestones",
                resolve: context =>
                    data.GetUserTasksForMatterMilestone(context.Source as Matter));

            var arguments = new QueryArguments(
                new[]
                {
                    new QueryArgument<StringGraphType>
                    {
                        Name = "roleName",
                        Description = "Name of the role"
                    }
                });

            Field<ContactType>("contact", "A contact for the matter",
                resolve:
                    context =>
                        data.GetContactForMatter(context.Source as Matter, (string) context.Arguments["roleName"]),
                arguments: arguments);

            Field<DebtType>("debt", "The debt information",
                resolve: context =>
                    data.GetDebtForMatter(
                        context.Source as Matter,
                        GetLeafNodes(context.FieldAst).Select(MapFieldNameToFqn).ToList()));
            IsTypeOf = value => value is Matter;
        }


        public List<string> GetLeafNodes(Field field)
        {
            return field.Selections.Select(item => item.Field.Name).ToList();
        }

        private static string MapFieldNameToFqn(string fieldName)
        {
            switch (fieldName)
            {
                case "originalDebt":
                    return "Matter.debt_orig_debt_bal_ud";
                case "claimNumber":
                    return "Matter.debt_claim_number_ud";
                case "dateOfService":
                    return "Matter.debt_n1_date_of_service_ud";
                case "totalCosts":
                    return "Matter.debt_tot_enf_costs_ud";
                case "interest":
                    return "Matter.debt_Totalinterestappliedtothismatter_ud";
                case "disbursements":
                    return "Matter.debt_Totalfeesforthematter_ud";
                case "paidToDate":
                    return "Matter.debt_Totalpaymentsforthismatter_ud";
                case "currentBalance":
                    return "Matter.debt_summary_balance_ud";
                default:
                    throw new ArgumentException($"Unknown field '{fieldName}'");
            }
        }
    }
}