using ControlMeasurements.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlMeasurements.Data
{
    public class MeasurementsContext : DbContext

    {
        public MeasurementsContext(DbContextOptions<MeasurementsContext> options)
            : base(options)
        { }

        public DbSet<MeasurementCategory> MeasurementsCategory { get; set; }
    }
}