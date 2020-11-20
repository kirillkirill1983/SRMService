using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationApi.Domain;
using System;

namespace ServiceStationApi.Infrastructure.Configurations

{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car");

            builder.HasKey(o => o.Id);

            builder.Property(t => t.CarModel)
                   .HasMaxLength(50)
                   .HasColumnName("Car_model");

            builder.Property(m => m.Number)
                .HasColumnName("Number")
                .HasMaxLength(50);

            builder.Property(p => p.Date)
                .HasColumnType("date")
                .HasColumnName("Date");

            builder
                .HasOne(m => m.Customer)
                .WithMany(a => a.Cars)
                .HasForeignKey(m => m.CustomerId);

        }
    }

}
