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

        public Table(Guid restaurantId, string name, int order, int capacity, Status status)
        {
            RestaurantId = restaurantId;
            Name = name;
            Order = order;
            Capacity = capacity;
            Status = status;
        }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public int Capacity { get; set; }

        public Status Status { get; set; }
    }
}
