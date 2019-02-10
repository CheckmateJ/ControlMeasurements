using System;

namespace ControlMeasurements.Models
{
    public class MeasurementCategory
    {
        public Guid Id { get; set; }
        public PlaceType PlaceType { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public int Value { get; set; }
    }

    public enum PlaceType
    {
        Kitchen,
        Bathroom,
        LivingRoom,
        BedRoom,
        ChildRoom,
        Corridor
    }

    public enum MeasurementType
    {
        Water,
        Heat,
        Energy
    }
}