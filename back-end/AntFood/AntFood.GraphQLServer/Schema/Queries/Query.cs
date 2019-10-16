using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Domain.Services;

namespace AntFood.GraphQLServer.Schema.Queries
{
    public class Query
    {
        private readonly IRestaurantService _restaurantService;

        public Query(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<RestaurantContract> GetRestaurant(Guid id)
        {
            return await _restaurantService.GetRestaurantAsync(id);
        }
    }
}
