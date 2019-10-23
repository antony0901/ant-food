using AntFood.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using AntFood.Contracts.Enums;

namespace AntFood.Domain.Models
{
    public class Restaurant : AggregateRootBase
    {
        public Restaurant()
        {
        }

        public Restaurant(string name)
            : base()
        {
            Name = name;
            Status = Status.Inactive;
        }

        public Status Status { get; set; }

        public string Name { get; set; }

        public List<Table> Tables { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; }

        public List<Order> Orders { get; set; }
    }
}
