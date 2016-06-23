using DebtsModel.DTO;
using GraphQL.Types;

namespace DebtsModel.GraphQLDTO
{
    public class EarnerType : ObjectGraphType
    {
        public EarnerType(ALBData data)
        {
            Name = "Earner";
            Description = "An earner - Fee Earner or Supervisor";

            Field<StringGraphType>("name", "The name of the earner.");

            Field<AddressType>("address", "Address of the earner",
                resolve: context => data.GetAddressForEarner(context.Source as Earner));

            Field<AdditionalAddressElementType>("url", "Url for an address",
                resolve: context => data.GetUrlForEarner(context.Source as Earner));

            IsTypeOf = value => value is Earner;
        }
    }

    public class FeeEarnerType : EarnerType
    {
        public FeeEarnerType(ALBData data):base(data)
        {            
        }
    }

    public  class SupervisorType : EarnerType
    {
        public SupervisorType(ALBData data):base(data)
        {            
        }
    }
}
