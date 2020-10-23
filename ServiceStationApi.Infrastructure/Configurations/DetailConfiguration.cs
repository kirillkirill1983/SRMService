using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationApi.Domain;

namespace ServiceStationApi.Infrastructure.Configurations

{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.ToTable("Details");

            builder.HasKey(o => o.Id);

            builder.Property(t => t.Name)
                   .HasMaxLength(50)
                   .HasColumnName("Name");

            builder.Property(m => m.Price)
                .HasColumnName("Price")
                .HasColumnType("money");

            builder
                .HasOne(m => m.Work)
                .WithMany(a => a.Details)
                .HasForeignKey(m => m.WorkId);

        }
    }

}
