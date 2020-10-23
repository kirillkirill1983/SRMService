using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationApi.Domain;

namespace ServiceStationApi.Infrastructure.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(o => o.Id);

            builder.Property(t => t.Description)
                .HasMaxLength(50)
                .HasColumnName("Description");

            builder.Property(t => t.Date)
                   .HasColumnName("Date")
                   .HasColumnType("date");
           builder
                .HasKey(t => new { t.WorkerId, t.WorkId });

           builder
                .HasOne(sc => sc.Work)
                .WithMany(s => s.Services)
                .HasForeignKey(sc => sc.WorkId);

           builder
                .HasOne(sc => sc.Worker)
                .WithMany(c => c.Services)
                .HasForeignKey(sc => sc.WorkerId);
        }
    }
}
