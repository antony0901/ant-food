using System;
using AntFood.Contracts.Enums;

namespace AntFood.Contracts
{
    public class FoodType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
