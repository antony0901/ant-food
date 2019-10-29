﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AntFood.Domain.Services
{
    public class RestaurantService : ApplicationServiceBase, IRestaurantService
    {
        public RestaurantService(AFDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<Contracts.RestaurantContract> AddRestaurantAsync(string name)
        {
            var newRestaurant = new Models.Restaurant(name);
            _dbContext.Set<Models.Restaurant>().Add(newRestaurant);
            await _dbContext.SaveChangesAsync();

            return new Contracts.RestaurantContract
            {
                Id = newRestaurant.Id,
                Name = name
            };
        }

        public async Task<Contracts.RestaurantContract> GetRestaurantAsync(Guid id)
        {
            var restaurant = await _dbContext.Set<Restaurant>().SingleOrDefaultAsync(x => x.Id == id);

            return new Contracts.RestaurantContract
            {
                Id = restaurant.Id,
                Name = restaurant.Name
            };
        }

        public async Task<Contracts.RestaurantContract[]> GetRestaurantsAsync()
        {
            var restaurants = await _dbContext.Set<Restaurant>().ToArrayAsync();
            var rs = new List<Contracts.RestaurantContract>();
            foreach (var item in restaurants)
            {
                rs.Add(new Contracts.RestaurantContract
                {
                    Id = item.Id,
                    Name = item.Name,
                    Status = item.Status
                });
            }

            return rs.ToArray();
        }
    }
}
