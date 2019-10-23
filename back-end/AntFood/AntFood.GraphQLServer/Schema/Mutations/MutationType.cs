using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntFood.GraphQLServer.Schema.Mutations;
using HotChocolate.Types;

namespace AntFood.GraphQLServer.Schema
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(x => x.AddRestaurant(default));
            descriptor.Field(x => x.AddTable(default));
        }
    }
}
