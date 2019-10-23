using System;
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

        public async Task<RestaurantContract> AddRestaurantAsync(string name)
        {
            var newRestaurant = new Restaurant(name);
            _dbContext.Set<Restaurant>().Add(newRestaurant);
            await _dbContext.SaveChangesAsync();

            return new RestaurantContract
            {
                Id = newRestaurant.Id,
                Name = name
            };
        }

        public async Task<RestaurantContract> GetRestaurantAsync(Guid id)
        {
            var restaurant = await _dbContext.Set<Restaurant>().SingleOrDefaultAsync(x => x.Id == id);

            return new RestaurantContract
            {
                Id = restaurant.Id,
                Name = restaurant.Name
            };
        }

        public async Task<RestaurantContract[]> GetRestaurantsAsync()
        {
            var restaurants = await _dbContext.Set<Restaurant>().ToArrayAsync();
            var rs = new List<RestaurantContract>();
            foreach (var item in restaurants)
            {
                rs.Add(new RestaurantContract
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
