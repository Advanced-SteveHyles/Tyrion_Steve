using DebtsModel.DTO;
using GraphQL.Types;

namespace DebtsModel.GraphQLDTO
{
    public class AddressType : ObjectGraphType
    {
        public AddressType(ALBData data)
        {
            Name = "Address";
            Description = "An address";

            Field<IntGraphType>("addressId", "address id");

            IsTypeOf = value => value is Address;
        }
    }
}