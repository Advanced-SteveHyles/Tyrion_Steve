using System;
using GraphQL.Types;

namespace DebtsModel
{
    public class ALBSchema : Schema
    {
        public ALBSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (ObjectGraphType)resolveType(typeof (Query));
        }
    }
}
