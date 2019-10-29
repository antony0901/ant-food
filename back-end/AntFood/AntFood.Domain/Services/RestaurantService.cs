using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Contracts.Types;
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

        public async Task<Contracts.RestaurantType> AddRestaurantAsync(string name)
        {
            var newRestaurant = new Models.Restaurant(name);
            _dbContext.Set<Models.Restaurant>().Add(newRestaurant);
            await _dbContext.SaveChangesAsync();

            return new Contracts.RestaurantType
            {
                Id = newRestaurant.Id,
                Name = name
            };
        }

        public async Task<Contracts.RestaurantType> GetRestaurantAsync(Guid id)
        {
            var restaurant = await _dbContext.Set<Restaurant>().SingleOrDefaultAsync(x => x.Id == id);

            return new Contracts.RestaurantType
            {
                Id = restaurant.Id,
                Name = restaurant.Name
            };
        }

        public async Task<Contracts.RestaurantType[]> GetRestaurantsAsync()
        {
            var restaurants = await _dbContext.Set<Restaurant>().ToArrayAsync();
            var rs = new List<Contracts.RestaurantType>();
            foreach (var item in restaurants)
            {
                rs.Add(new Contracts.RestaurantType
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
                .Include(o => o.OrderItems)
                .SingleOrDefaultAsync(o => o.Id == orderId);

            return new OrderType
            {
                Id = order.Id,
                TableId = order.TableId,
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

        public async Task<OrderType[]> GetOrdersAsync(Guid restaurantId)
        {
            var orders = await _dbContext.Set<Order>()
                .Include(o => o.OrderItems)
                .Where(o => o.RestaurantId == restaurantId)
                .ToListAsync();

            return orders.Select(o => new OrderType
            {
                Id = o.Id,
                TableId = o.TableId,
                PaidStatus = o.PaidStatus,
                TotalPrice = o.TotalPrice()
            }).ToArray();
        }
    }
}
