using System;
using AntFood.Contracts.Enums;

namespace AntFood.Contracts
{
    public class RestaurantType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }
    }
}
