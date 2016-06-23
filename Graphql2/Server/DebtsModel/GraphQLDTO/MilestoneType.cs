using DebtsModel.DTO;
using GraphQL.Types;

namespace DebtsModel.GraphQLDTO
{
    public class MilestoneType : ObjectGraphType
    {

        public MilestoneType()
        {
            Field<StringGraphType>("mileStoneName");

            Field<ListGraphType<UserTaskType>>("actions", "The actions available",
                resolve:context=> (context.Source as Milestone).UserTasks);
            
            IsTypeOf = value => value is Milestone;
        }
    }
}