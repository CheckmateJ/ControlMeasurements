using ControlMeasurements.Models;
using System.Collections.Generic;

namespace ControlMeasurements.ViewModels
{
    public class Card
    {
        public MeasurementType MeasurementType { get; set; }

        public List<Subcard> Subcards { get; set; }
    }

    public class Subcard
    {
        public PlaceType PlaceType { get; set; }

        public List<MeasurementView> MeasurementViews { get; set; }
    }

    public class MeasurementView
    {
        public Measurement Measurement { get; set; }

        public double? Change { get; set; }
    }
}