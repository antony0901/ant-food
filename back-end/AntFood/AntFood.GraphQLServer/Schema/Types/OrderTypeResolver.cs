using System.Threading.Tasks;
using AntFood.Contracts.Types;
using AntFood.Domain.Services;
using HotChocolate;

namespace AntFood.GraphQLServer.Types
{
    public class OrderTypeResolver
    {
        public async Task<OrderItemType[]> Items(OrderType order, [Service]IRestaurantService restaurantService) =>
            await restaurantService.GetOrderItemsAsync(order.Id);
    }
}
