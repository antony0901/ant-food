using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntFood.Contracts;

namespace AntFood.Domain.Services
{
    public interface ITableService
    {
        Task<TableType> AddTableAsync(AddTableInput addTableType);

        Task<TableType[]> GetTablesAsync(Guid restaurantId);
    }
}
