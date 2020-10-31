using Microsoft.EntityFrameworkCore;
using ServiceStationApi.Domain;
using ServiceStationApi.Infrastructure.Configurations;

namespace ServiceStationApi.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Work> Worker { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) :
            base(dbContextOptions)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.
                ApplyConfiguration(new CarConfiguration());
            modelBuilder.
                ApplyConfiguration(new DetailConfiguration());
            modelBuilder.
                ApplyConfiguration(new WorkConfigure());
            modelBuilder.
                ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.
                ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.
                ApplyConfiguration(new ServiceConfiguration());
        }


        
    }
}
