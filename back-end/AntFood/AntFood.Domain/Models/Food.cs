using AntFood.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Models
{
    public class Food : AggregateRootBase
    {
        protected Food()
        {
        }

        public Food(string name)
            : base()
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
