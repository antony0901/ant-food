using System;
using AntFood.Contracts;
using AntFood.Contracts.Types;
using AntFood.Domain.Services;
using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace AntFood.GraphQLServer.Types
{
    public class OrderDetailsType : ObjectType<OrderType>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderType> descriptor)
        {
            descriptor.Field(t => t.Id);
            descriptor.Field("table")
                .Resolver(context =>
                {
                    var tableService = context.Service<ITableService>();

                    IDataLoader<Guid, TableType> dataLoader = context.BatchDataLoader<Guid, TableType>(
                        "tableById",
                        tableService.GetTablesAsync);

                    return dataLoader.LoadAsync(context.Parent<OrderType>().TableId);
                });

            descriptor.Field(t => t.PaidStatus);
            descriptor.Field(t => t.TotalPrice);
            descriptor.Field("items")
                .Resolver(context => context.Service<IRestaurantService>().GetOrderItemsAsync(
                    context.Parent<OrderType>().Id));
        }
    }
}
