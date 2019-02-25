using System;
using System.ComponentModel.DataAnnotations;

namespace ControlMeasurements.Models
{
    public class Measurement
    {
        public Guid Id { get; set; }

        public PlaceType PlaceType { get; set; }

        public MeasurementType MeasurementType { get; set; }

        public double Value { get; set; }

        public DateTime Date { get; set; }

        public Measurement()
        {
            Date = DateTime.Now;
        }
    }
}