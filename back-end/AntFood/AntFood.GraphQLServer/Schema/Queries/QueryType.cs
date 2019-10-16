using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntFood.GraphQLServer.Schema.Mutations;
using HotChocolate.Types;

namespace AntFood.GraphQLServer.Schema.Queries
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.GetRestaurant(default));
        }
    }
}
