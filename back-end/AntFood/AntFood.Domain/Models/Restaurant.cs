using AntFood.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Models
{
    public class Restaurant : AggregateRootBase
    {
        protected Restaurant()
        {
        }

        public Restaurant(string name)
            : base()
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<Table> Tables { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; }

        public List<Order> Orders { get; set; }
    }
}
