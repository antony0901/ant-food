using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Contracts.Types;
using AntFood.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<OrderType> GetOrderAsync(Guid orderId)
        {
            var order = await _dbContext.Set<Order>()
                .Include(o => o.Table)
                .Include(o => o.OrderItems)
                .SingleOrDefaultAsync(o => o.Id == orderId);

            return new OrderType
            {
                Id = order.Id,
                Table = order.Table.Name,
                PaidStatus = order.PaidStatus,
                TotalPrice = order.TotalPrice()
            };
        }

        public async Task<OrderItemType[]> GetOrderItemsAsync(Guid orderId)
        {
            var order = await _dbContext.Set<Order>()
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Food)
                .SingleOrDefaultAsync(o => o.Id == orderId);

            return order.OrderItems.Select(oi => new OrderItemType
            {
                Food = oi.Food.Name,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice
            }).ToArray();
        }
    }
}
