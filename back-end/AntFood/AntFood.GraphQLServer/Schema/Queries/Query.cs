﻿using System;
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
        private readonly ITableService _tableService;

        public Query(IRestaurantService restaurantService, ITableService tableService)
        {
            _restaurantService = restaurantService;
            _tableService = tableService;
        }

        public async Task<RestaurantContract> GetRestaurant(Guid id)
        {
            return await _restaurantService.GetRestaurantAsync(id);
        }

        public async Task<RestaurantContract[]> GetRestaurants()
        {
            return await _restaurantService.GetRestaurantsAsync();
        }

        public async Task<TableContract[]> GetTablesOfRestaurant(Guid id)
        {
            return await _tableService.GetTablesAsync(id);
        }
    }
}
