using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationApi.Domain;

namespace ServiceStationApi.Infrastructure.Configurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Worker");

            builder.HasKey(o => o.Id);

            builder.Property(l => l.Name)
                   .HasMaxLength(20)
                   .HasColumnName("Name");

            builder.Property(t => t.Phone)
                   .HasMaxLength(20)
                   .HasColumnName("Phone");

        }
    }
}
