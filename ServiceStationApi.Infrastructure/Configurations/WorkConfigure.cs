using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationApi.Domain;



namespace ServiceStationApi.Infrastructure.Configurations
{
    public class WorkConfigure : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.ToTable("Work");

            builder.HasKey(o => o.Id);

            builder.Property(t => t.TypeWokr)
                   .HasMaxLength(50)
                   .HasColumnName("TypeWork");

            builder.Property(m => m.Price)
                .HasColumnName("Price")
                .HasColumnType("money");
        }
    }
}
