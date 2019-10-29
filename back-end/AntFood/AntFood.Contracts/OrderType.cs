using System;
using AntFood.Contracts.Enums;

namespace AntFood.Contracts.Types
{
    public class OrderType
    {
        public Guid Id { get; set; }

        public Guid TableId { get; set; }

        public PaidStatus PaidStatus { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
