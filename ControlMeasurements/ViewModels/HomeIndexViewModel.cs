using ControlMeasurements.Models;
using System.Collections.Generic;

namespace ControlMeasurements.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Measurement> WaterMeasurements { get; set; }

        public List<Measurement> EnergyMeasurements { get; set; }

        public List<Measurement> HeatMeasurements { get; set; }

        public List<Measurement> KitchenHotWater { get; set; }

        public List<Measurement> BathroomHotWater { get; set; }

        public List<Measurement> KitchenColdWater { get; set; }

        public List<Measurement> BathroomColdWater { get; set; }

        public List<Measurement> LivingRoom { get; set; }

        public List<Measurement> BedRoom { get; set; }

        public List<Measurement> ChildRoom { get; set; }

        public List<Measurement> Corridor { get; set; }

        public double KitchenHotWaterMeasurementChange { get; set; }

        public double KitchenColdWaterMeasurementChange { get; set; }

        public double BathroomHotWaterMeasurementChange { get; set; }

        public double BathroomColdWaterMeasurementChange { get; set; }

        public double LivingRoomMeasurementChange { get; set; }

        public double BedRoomMeasurementChange { get; set; }

        public double ChildRoomMeasurementChange { get; set; }

        public double CorridorMeasurementChange { get; set; }
    }
}