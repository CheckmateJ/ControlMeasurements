using ControlMeasurements.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlMeasurements.Data
{
    public class MeasurementsContext : DbContext

    {
        public MeasurementsContext(DbContextOptions<MeasurementsContext> options)
            : base(options)
        { }
        public DbSet<WaterMeasurement> WaterMeasurements { get; set; }
        public DbSet<HeatingMeasurement>HeatingMeasurements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<HeatingMeasurement>().ToTable("HeatingMeasurement");
        }
    }
}
