using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Models.Builders
{
    public class FoodBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Food>().ToTable("Foods");

            entity.HasKey(x => x.Id);
        }
    }
}
