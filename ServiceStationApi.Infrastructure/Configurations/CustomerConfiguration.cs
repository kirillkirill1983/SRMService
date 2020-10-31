using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationApi.Domain;
using System;

namespace ServiceStationApi.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(o => o.Id );

            builder.Property(t => t.Name)
                   .HasMaxLength(50)
                   .HasColumnName("Name");

            builder.Property(t => t.Phone)
                   .HasMaxLength(50)
                   .HasColumnName("Phone");

        }
    }
}
