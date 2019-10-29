using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AntFood.Domain.Services;
using AntFood.GraphQLServer.Schema.Mutations;
using AntFood.GraphQLServer.Schema.Types;
using HotChocolate;
using HotChocolate.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors.Definitions;
using HotChocolate.Types.Relay;

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
        }
    }
}
