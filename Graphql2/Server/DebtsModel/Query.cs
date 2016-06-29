using System.Threading.Tasks;
using DebtsModel.DTO;
using DebtsModel.GraphQLDTO;
using GraphQL.Types;

namespace DebtsModel
{
    public class Query : ObjectGraphType
    {
        public Query(ALBData data)
        {
            Name = "Query";

            Field<ListGraphType<PlanetType>>("planets", "List of planets",
                resolve: context => data.GetPlanets());

            Field<ListGraphType<ResourcesType>>("Resources", "List of all known resources",
                resolve: context => data.GetResources());


            Field<MatterType>(
                "matter",
                arguments: new QueryArguments(
                    new[]
                    {
                        new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "reference",
                            Description = "reference of the matter"
                        }
                    }),
                resolve: context => data.GetMatterByReferenceAsync((string)context.Arguments["reference"])
                );

            Field<ClientType>(
                "client",
                arguments: new QueryArguments(
                    new[]
                    {
                        new QueryArgument<StringGraphType> {Name = "id", Description = "guid of the client"}
                    }),
                resolve: context => GetClientAsync(data, context)
                );

            //Field<UserType>(
            //    "user",
            //    arguments: new QueryArguments(
            //        new[]
            //        {
            //            new QueryArgument<StringGraphType> {Name = "userName", Description = "user name of the user"}
            //        }),
            //    resolve: context => GetUserAsync(data, context)
            //    );
        }

        private static Task<Client> GetClientAsync(ALBData data, ResolveFieldContext context)
        {
            if (context.Arguments["id"] != null)
                return data.FindClientAsync((string)context.Arguments["id"]);

            return null;
        }

        //private static Task<User> GetUserAsync(ALBData data, ResolveFieldContext context)
        //{
        //    if (context.Arguments["userName"] != null)
        //        return data.FindUserAsync((string)context.Arguments["userName"]);

        //    return null;
        //}
    }
}