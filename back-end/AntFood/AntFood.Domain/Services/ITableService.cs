﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntFood.Contracts;

namespace AntFood.Domain.Services
{
    public interface ITableService
    {
        Task<TableContract> AddTableAsync(AddTable addTableType);

        Task<TableContract[]> GetTablesAsync(Guid restaurantId);
    }
}
