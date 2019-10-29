using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AntFood.Domain.Services;
using AntFood.GraphQLServer.Schema.Mutations;
using AntFood.GraphQLServer.Types;
using AntFood.GraphQLServer.Schema.Types;
using HotChocolate;
using HotChocolate.Configuration;
using HotChocolate.Types;

namespace AntFood.GraphQLServer.Schema.Queries
{
    public class QueryType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field(name: "restaurants")
                .Type<ListType<RestaurantType>>()
                .Resolver(ctx =>
                {
                    var restaurantsService = ctx.Service<IRestaurantService>();
                    return restaurantsService.GetRestaurantsAsync().Result;
                });

            descriptor.Field("order")
                .Type<NonNullType<OrderDetailsType>>()
                .Argument(argumentName: "id", argumentDescriptor: x => x.Type<UuidType>())
                .Resolver(ctx => 
                {
                    var restaurantsService = ctx.Service<IRestaurantService>();
                    var restId = ctx.Argument<Guid>("id");
                    return restaurantsService.GetOrderAsync(restId).Result;
                });
        }
    }
}
