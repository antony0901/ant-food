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
    public class TableService : ApplicationServiceBase, ITableService
    {
        public TableService(AFDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<TableType> AddTableAsync(AddTableInput contract)
        {
            var newTable = new Table(contract.RestaurantId, contract.Name, contract.Order, contract.Capacity, contract.Status);
            _dbContext.Set<Table>().Add(newTable);
            await _dbContext.SaveChangesAsync();

            return new TableType
            {
                Id = newTable.Id,
                Name = newTable.Name,
                Order = newTable.Order,
                Capacity = newTable.Capacity,
                Status = newTable.Status
            };
        }

        public async Task<TableType[]> GetTablesAsync(Guid restaurantId)
        {
            var tables = await _dbContext.Set<Table>()
                .Where(x => x.RestaurantId == restaurantId).ToArrayAsync();
            var rs = new List<TableType>();
            foreach (var item in tables)
            {
                rs.Add(new TableType
                {
                    Id = item.Id,
                    Name = item.Name,
                    Capacity = item.Capacity,
                    Status = item.Status
                });
            }

            return rs.ToArray();
        }
    }
}
