using ControlMeasurements.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlMeasurements.Data
{
    public class WaterContext : DbContext
    {
        public WaterContext(DbContextOptions<WaterContext> options)
            : base(options)
        { }
        public DbSet<Water> Waters { get; set; }
    }
}
