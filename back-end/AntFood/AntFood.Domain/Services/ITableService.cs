using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AntFood.Contracts;

namespace AntFood.Domain.Services
{
    public interface ITableService
    {
        Task<TableType> AddTableAsync(AddTable addTableType);

        Task<TableType[]> GetTablesAsync(Guid restaurantId);

        Task<IReadOnlyDictionary<Guid, TableType>> GetTablesAsync(IReadOnlyCollection<Guid> tableIds);
    }
}
