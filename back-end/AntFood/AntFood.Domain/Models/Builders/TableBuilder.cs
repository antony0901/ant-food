using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Models.Builders
{
    public class TableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Table>().ToTable("Tables");

            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Restaurant)
                .WithMany(x => x.Tables)
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
