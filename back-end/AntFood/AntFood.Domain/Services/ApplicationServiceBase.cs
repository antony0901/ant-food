using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Services
{
    public abstract class ApplicationServiceBase
    {
        protected readonly AFDbContext _dbContext;

        public ApplicationServiceBase(AFDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
