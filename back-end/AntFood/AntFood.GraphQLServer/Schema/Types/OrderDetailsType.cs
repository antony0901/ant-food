using AntFood.Contracts.Types;
using AntFood.Domain.Services;
using HotChocolate.Types;

namespace AntFood.GraphQLServer.Types
{
    public class OrderDetailsType : ObjectType<OrderType>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderType> descriptor)
        {
            descriptor.Field(t => t.Id);
            descriptor.Field(t => t.Table);
            descriptor.Field(t => t.PaidStatus);
            descriptor.Field(t => t.TotalPrice);
            descriptor.Field("items")
                .Resolver(context => context.Service<IRestaurantService>().GetOrderItemsAsync(
                    context.Parent<OrderType>().Id));
        }
    }
}
