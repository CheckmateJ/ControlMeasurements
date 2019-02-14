using ControlMeasurements.Models;
using System.Collections.Generic;

namespace ControlMeasurements.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Measurement> WaterMeasurements { get; set; }

        public List<Measurement> HeatMeasurements { get; set; }

        public List<Measurement> EnergyMeasurements { get; set; }
    }
}