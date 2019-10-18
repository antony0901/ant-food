using AntFood.Contracts.Enums;
using AntFood.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntFood.Domain.Models
{
    public class Order : EntityBase
    {
        public Order()
        {
        }

        public Order(Guid restaurantId, Guid tableId)
        {
            RestaurantId = restaurantId;
            TableId = tableId;
        }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public Guid TableId { get; set; }

        public Table Table { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public PaidStatus PaidStatus { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; }

        public decimal TotalPrice()
        {
            return OrderItems.Sum(x => x.Quantity * x.UnitPrice);
        }
    }
}
