using System;

namespace ControlMeasurements.Models
{
    public class Measurement
    {
        public Guid Id { get; set; }
        public PlaceType PlaceType { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public int Value { get; set; }
    }
}