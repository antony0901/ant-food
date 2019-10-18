using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntFood.Contracts;

namespace AntFood.Domain.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantContract> AddRestaurantAsync(string name);

        Task<RestaurantContract> GetRestaurantAsync(Guid id);

        Task<RestaurantContract[]> GetRestaurantsAsync();
    }
}
