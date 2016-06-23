using DebtsModel.DTO;
using GraphQL.Types;

namespace DebtsModel.GraphQLDTO
{
    public class UserTaskType : ObjectGraphType
    {

        public UserTaskType()
        {
            Field<StringGraphType>("taskName");
            Field<DateGraphType>("dueBy");
            
            IsTypeOf = value => value is UserTask;
        }
    }
}