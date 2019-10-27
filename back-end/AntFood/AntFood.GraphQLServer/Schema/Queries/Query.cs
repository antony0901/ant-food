using System;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Contracts.Types;
using AntFood.Domain.Services;

namespace AntFood.GraphQLServer.Schema.Queries
{
    public class Query
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ITableService _tableService;

        public Query(IRestaurantService restaurantService, ITableService tableService)
        {
            _restaurantService = restaurantService;
            _tableService = tableService;
        }

        public async Task<RestaurantType> GetRestaurant(Guid id)
        {
            return await _restaurantService.GetRestaurantAsync(id);
        }

        public async Task<RestaurantType[]> GetRestaurants()
        {
            return await _restaurantService.GetRestaurantsAsync();
        }

        public async Task<TableType[]> GetTablesOfRestaurant(Guid id)
        {
            return await _tableService.GetTablesAsync(id);
        }

        public async Task<OrderType> GetOrder(Guid id)
        {
            return await _restaurantService.GetOrderAsync(id);
        }
    }
}
