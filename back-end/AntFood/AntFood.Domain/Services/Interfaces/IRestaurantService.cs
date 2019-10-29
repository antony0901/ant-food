using System;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Contracts.Types;

namespace AntFood.Domain.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantType> AddRestaurantAsync(string name);

        Task<RestaurantType> GetRestaurantAsync(Guid id);

        Task<RestaurantType[]> GetRestaurantsAsync();

        Task<OrderType> GetOrderAsync(Guid orderId);

        Task<OrderItemType[]> GetOrderItemsAsync(Guid orderId);

        Task<OrderType[]> GetOrdersAsync(Guid restaurantId);
    }
}
