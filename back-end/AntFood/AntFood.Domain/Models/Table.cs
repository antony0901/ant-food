using AntFood.Contracts.Enums;
using AntFood.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Models
{
    public class Table : EntityBase
    {
        public Table()
        {
        }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public string Name { get; set; }

        public string Order { get; set; }

        public int Capicity { get; set; }

        public Status Status { get; set; }
    }
}
