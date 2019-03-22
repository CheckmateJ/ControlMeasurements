using ControlMeasurements.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ControlMeasurements.Data
{
    public class MeasurementsContext : DbContext

    {
        public MeasurementsContext(DbContextOptions<MeasurementsContext> options)
            : base(options)
        { }

        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Amount> Amounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Amount>().HasData(new Amount { Id = Guid.Parse("87243441-0C03-4DE3-B110-40CAFA170F66"), MeasurementType = MeasurementType.HotWater, Price = 0 });
            modelBuilder.Entity<Amount>().HasData(new Amount { Id = Guid.Parse("2695F178-3C7F-46E1-A41B-6EAD72724AF8"), MeasurementType = MeasurementType.ColdWater, Price = 0 });
            modelBuilder.Entity<Amount>().HasData(new Amount { Id = Guid.Parse("0763C616-4099-48D9-BE6C-7B332DB79FE0"), MeasurementType = MeasurementType.Heat, Price = 0 });
            modelBuilder.Entity<Amount>().HasData(new Amount { Id = Guid.Parse("4A9A1542-2BB1-4398-A8EA-B48EA8009733"), MeasurementType = MeasurementType.Energy, Price = 0 });
        }
    }
}