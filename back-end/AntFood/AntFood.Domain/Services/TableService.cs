using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Domain.Models;

namespace AntFood.Domain.Services
{
    public class TableService : ApplicationServiceBase
    {
        public TableService(AFDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<TableContract> AddTableAsync(AddTableContract contract)
        {
            var newTable = new Table(contract.RestaurantId, contract.Name, contract.Order, contract.Capacity, contract.Status);
            _dbContext.Set<Table>().Add(newTable);
            await _dbContext.SaveChangesAsync();

            return new TableContract
            {
                Id = newTable.Id,
                Name = newTable.Name,
                Order = newTable.Order,
                Capacity = newTable.Capacity,
                Status = newTable.Status
            };
        }
    }
}
