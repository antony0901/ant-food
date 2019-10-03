using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntFood.Domain.Models.Builders
{
    public class PaymentMethodBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods");

            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Restaurant)
                .WithMany(x => x.PaymentMethods)
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
