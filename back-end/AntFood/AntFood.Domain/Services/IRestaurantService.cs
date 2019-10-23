using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntFood.Contracts;

namespace AntFood.Domain.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantType> AddRestaurantAsync(string name);

        Task<RestaurantType> GetRestaurantAsync(Guid id);

        Task<RestaurantType[]> GetRestaurantsAsync();
    }
}
