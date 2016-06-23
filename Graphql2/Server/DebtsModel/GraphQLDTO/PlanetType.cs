using DebtsModel.DTO;
using GraphQL.Types;

namespace DebtsModel.GraphQLDTO
{
    public class PlanetType : ObjectGraphType
    {
        public PlanetType(ALBData data)
        {
            Field<StringGraphType> ("name", "Name of planet");

            Field<ListGraphType<ResourcesType>>("resources", "List of resources",
                resolve: context => data.GetResourcesForPlanet(context.Source as Planet));
        }
    }

    public class ResourcesType:ObjectGraphType
    {
        public ResourcesType()
        {
            Field<StringGraphType>("name", "Name of resource");
        }
    }
}