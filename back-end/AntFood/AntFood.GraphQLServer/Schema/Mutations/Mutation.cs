using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Domain.Services;

namespace AntFood.GraphQLServer.Schema.Mutations
{
    public class Mutation
    {
        private readonly IRestaurantService _restaurantService;

        public Mutation(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<RestaurantType> AddRestaurant(string name)
        {
            return await _restaurantService.AddRestaurantAsync(name);
        }
    }
}
