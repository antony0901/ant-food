using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Contracts.Types;

namespace AntFood.Domain.Services
{
    public interface IOrderService
    {
        Task<OrderType[]> GetOrdersAsync(Guid restaurantId);
    }
}
