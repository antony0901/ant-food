using AntFood.Domain.Models.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace AntFood.Domain
{
    public class AFDbContext : DbContext
    {
        public AFDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FoodBuilder.Build(modelBuilder);
            OrderBuilder.Build(modelBuilder);
            OrderItemBuilder.Build(modelBuilder);
            PaymentMethodBuilder.Build(modelBuilder);
            RestaurantBuilder.Build(modelBuilder);
            TableBuilder.Build(modelBuilder);
        }
    }
}
