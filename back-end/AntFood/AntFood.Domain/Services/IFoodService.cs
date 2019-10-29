using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntFood.Contracts;

namespace AntFood.Domain.Services
{
    public interface IFoodService
    {
        Task<FoodContract[]> AddFoodsServices(AddFood[] addFoodContracts);

        Task<FoodContract[]> GetTablesAsync(Guid restaurantId);
    }
}
