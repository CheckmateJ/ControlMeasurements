using ControlMeasurements.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlMeasurements.Data
{
    public class MeasurementsContext : DbContext

    {
        public MeasurementsContext(DbContextOptions<MeasurementsContext> options)
            : base(options)
        { }

        public DbSet<WaterMeasurement> WaterMeasurements { get; set; }
        public DbSet<HeatingMeasurement> HeatingMeasurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeatingMeasurement>().ToTable("HeatingMeasurement");
        }
    }
}