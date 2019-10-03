using AntFood.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Models
{
    public class PaymentMethod : EntityBase
    {
        public PaymentMethod()
        {
        }

        public PaymentMethod(Guid restaurantId, string name)
        {
            Name = name;
            RestaurantId = restaurantId;
        }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public string Name { get; set; }
    }
}
