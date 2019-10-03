using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Infrastructure
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
