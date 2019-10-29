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
        private readonly ITableService _tableService;

        public Mutation(IRestaurantService restaurantService, ITableService tableService)
        {
            _restaurantService = restaurantService;
            _tableService = tableService;
        }

        public async Task<RestaurantContract> AddRestaurant(string name)
        {
            return await _restaurantService.AddRestaurantAsync(name);
        }

        public async Task<TableContract> AddTable(AddTable input)
        {
            return await _tableService.AddTableAsync(input);
        }
    }
}
