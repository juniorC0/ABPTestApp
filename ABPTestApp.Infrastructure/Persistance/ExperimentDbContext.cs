using ABPTestApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace ABPTestApp.Infrastructure.Persistance
{
    public class ExperimentDbContext : DbContext
    {
        public ExperimentDbContext(DbContextOptions<ExperimentDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Experiment> Experiments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
