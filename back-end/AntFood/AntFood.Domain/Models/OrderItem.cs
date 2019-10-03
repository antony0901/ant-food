using AntFood.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Models
{
    public class OrderItem : EntityBase
    {
        public OrderItem(Guid orderId, Guid foodId, int quantity, decimal unitPrice)
        {
            OrderId = orderId;
            FoodId = foodId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public Guid FoodId { get; set; }

        public Food Food { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
