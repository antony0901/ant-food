using System;
using System.Threading;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Contracts.Types;
using AntFood.Domain.Services;
using HotChocolate;
using HotChocolate.Resolvers;

namespace AntFood.GraphQLServer.Types
{
    public class OrderTypeResolver
    {
        public async Task<OrderItemType[]> Items(OrderType order, [Service]IRestaurantService restaurantService) =>
            await restaurantService.GetOrderItemsAsync(order.Id);

        public async Task<TableType> Table(OrderType order, IResolverContext context, [Service]ITableService tableService)
        {
            return await context.BatchDataLoader<Guid, TableType>("tableById", ids => tableService.GetTablesAsync(ids))
                .LoadAsync(order.TableId, default(CancellationToken));
        }
    }
}
