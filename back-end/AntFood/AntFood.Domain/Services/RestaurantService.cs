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

        public async Task<RestaurantType> AddRestaurantAsync(string name)
        {
            var newRestaurant = new Restaurant(name);
            _dbContext.Set<Restaurant>().Add(newRestaurant);
            await _dbContext.SaveChangesAsync();

            return new RestaurantType
            {
                Id = newRestaurant.Id,
                Name = name
            };
        }

        public async Task<RestaurantType> GetRestaurantAsync(Guid id)
        {
            var restaurant = await _dbContext.Set<Restaurant>().SingleOrDefaultAsync(x => x.Id == id);

            return new RestaurantType
            {
                Id = restaurant.Id,
                Name = restaurant.Name
            };
        }

        public async Task<RestaurantType[]> GetRestaurantsAsync()
        {
            var restaurants = await _dbContext.Set<Restaurant>().ToArrayAsync();
            var rs = new List<RestaurantType>();
            foreach (var item in restaurants)
            {
                rs.Add(new RestaurantType
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
