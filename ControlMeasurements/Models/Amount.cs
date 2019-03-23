using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlMeasurements.Models
{
    public class Amount
    {
        public Guid Id { get; set; }

        public double Price { get; set; }

        public MeasurementType MeasurementType { get; set; }
    }
}