using System;
using System.ComponentModel.DataAnnotations;

namespace ControlMeasurements.Models
{
    public class Measurement
    {
        public Guid Id { get; set; }
        public PlaceType PlaceType { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public int Value { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MeasurementDate { get; set; }

        public Measurement()
        {
            MeasurementDate = DateTime.Now;
        }
    }
} 