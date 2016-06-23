using DebtsModel.DTO;
using GraphQL.Types;

namespace DebtsModel.GraphQLDTO
{
    public class AdditionalAddressElementType : ObjectGraphType
    {
        public AdditionalAddressElementType()
        {
            Name = "AdditionalAddressElement";
            Description = "Additional address elements. e.g. Telephone, Email etc";

            Field<StringGraphType>("value", "the value of the addition address element");

            IsTypeOf = value => value is AdditionalAddressElement;
        }
    }
}