using System;
using AntFood.GraphQLServer.Types;
using HotChocolate.Types;

namespace AntFood.GraphQLServer.Schema.Queries
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.GetRestaurant(default));
            descriptor.Field(x => x.GetRestaurants());
            descriptor.Field(x => x.GetTablesOfRestaurant(default));

            descriptor.Field("order")
                .Type<NonNullType<OrderDetailsType>>()
                .Argument(argumentName: "id", argumentDescriptor: x => x.Type<UuidType>())
                .Resolver(context => context.Parent<Query>().GetOrder(context.Argument<Guid>("id")));
        }
    }
}
