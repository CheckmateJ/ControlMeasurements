using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlMeasurements.Models
{
    public class Water
    {
        public Guid Id { get; set; }
        public string Place { get; set; }
        public int Measurement { get; set; }
    }
}
