using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntFood.Contracts;

namespace AntFood.Domain.Services
{
    public interface IFoodService
    {
        Task<FoodType[]> AddFoodsServices(AddFood[] addFoodContracts);

        Task<FoodType[]> GetTablesAsync(Guid restaurantId);
    }
}
