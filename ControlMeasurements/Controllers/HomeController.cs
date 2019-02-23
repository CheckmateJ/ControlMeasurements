using ControlMeasurements.Data;
using ControlMeasurements.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ControlMeasurements.Controllers
{
    public class HomeController : Controller
    {
        private MeasurementsContext _context;

        public HomeController(MeasurementsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var measurements = _context.Measurements;

            var result = new HomeIndexViewModel
            {
                KitchenHotWater = measurements
                                    .Where(x => x.MeasurementType == MeasurementType.HotWater)
                                    .Where(x => x.PlaceType == PlaceType.Kitchen)
                                    .OrderByDescending(x => x.Id).Take(3)
                                    .ToList(),
                BathroomHotWater = measurements
                                   .Where(x => x.MeasurementType == MeasurementType.HotWater)
                                   .Where(x => x.PlaceType == PlaceType.Bathroom)
                                   .OrderByDescending(x => x.Id).Take(3)
                                   .ToList(),
                KitchenColdWater = measurements
                                    .Where(x => x.MeasurementType == MeasurementType.ColdWater)
                                    .Where(x => x.PlaceType == PlaceType.Kitchen)
                                    .OrderByDescending(x => x.Id).Take(3)
                                    .ToList(),
                BathroomColdWater = measurements
                                   .Where(x => x.MeasurementType == MeasurementType.ColdWater)
                                   .Where(x => x.PlaceType == PlaceType.Bathroom)
                                   .OrderByDescending(x => x.Id).Take(3)
                                   .ToList(),
                LivingRoom = measurements
                                     .Where(x => x.MeasurementType == MeasurementType.Heat)
                                     .Where(x => x.PlaceType == PlaceType.LivingRoom)
                                     .OrderByDescending(x => x.Id).Take(3)
                                     .ToList(),
                BedRoom = measurements
                                     .Where(x => x.MeasurementType == MeasurementType.Heat)
                                     .Where(x => x.PlaceType == PlaceType.BedRoom)
                                     .OrderByDescending(x => x.Id).Take(3)
                                     .ToList(),
                ChildRoom = measurements
                                     .Where(x => x.MeasurementType == MeasurementType.Heat)
                                     .Where(x => x.PlaceType == PlaceType.ChildRoom)
                                     .OrderByDescending(x => x.Id).Take(3)
                                     .ToList(),
                Corridor = measurements
                                     .Where(x => x.MeasurementType == MeasurementType.Energy)
                                     .Where(x => x.PlaceType == PlaceType.Corridor)
                                     .OrderByDescending(x => x.Id).Take(3)
                                     .ToList(),

                KitchenHotWaterMeasurementChange = ComputeKitchenHotWater(),
                KitchenColdWaterMeasurementChange = ComputeKitchenColdWater(),
                BathroomHotWaterMeasurementChange = ComputeBathroomHotWater(),
                BathroomColdWaterMeasurementChange = ComputeBathroomColdWater(),
                LivingRoomMeasurementChange = ComputeLivingRoom(),
                BedRoomMeasurementChange = ComputeBedRoom(),
                ChildRoomMeasurementChange = ComputeChildRoom(),
                CorridorMeasurementChange = ComputeCorridor()
            };

            return View(result);
        }

        private double ComputeKitchenHotWater()
        {
            var measurements = _context.Measurements;
            var check = new HomeIndexViewModel
            {
                KitchenHotWater = measurements
                                   .Where(x => x.MeasurementType == MeasurementType.HotWater)
                                   .Where(x => x.PlaceType == PlaceType.Kitchen)
                                   .ToList(),
            };
            if (check.KitchenHotWater.Count > 1)
            {
                var value1 = measurements
                                    .Where(x => x.PlaceType == PlaceType.Kitchen)
                                    .Where(x => x.MeasurementType == MeasurementType.HotWater)
                                    .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).First();
                var value2 = measurements
                                        .Where(x => x.PlaceType == PlaceType.Kitchen)
                                        .Where(x => x.MeasurementType == MeasurementType.HotWater)
                                        .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).Skip(1).First();

                var result = value1.Value - value2.Value;

                return result;
            }
            return 0;
        }

        private double ComputeKitchenColdWater()
        {
            var measurements = _context.Measurements;
            var check = new HomeIndexViewModel
            {
                KitchenColdWater = measurements
                                    .Where(x => x.MeasurementType == MeasurementType.ColdWater)
                                    .Where(x => x.PlaceType == PlaceType.Kitchen)
                                    .ToList(),
            };

            if (check.KitchenColdWater.Count > 1)
            {
                var value1 = measurements
                                    .Where(x => x.PlaceType == PlaceType.Kitchen)
                                    .Where(x => x.MeasurementType == MeasurementType.ColdWater)
                                    .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).First();
                var value2 = measurements
                                        .Where(x => x.PlaceType == PlaceType.Kitchen)
                                        .Where(x => x.MeasurementType == MeasurementType.ColdWater)
                                        .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).Skip(1).First();

                var result = value1.Value - value2.Value;

                return result;
            }
            return 0;
        }

        private double ComputeBathroomHotWater()
        {
            var measurements = _context.Measurements;
            var check = new HomeIndexViewModel
            {
                BathroomHotWater = measurements
                                   .Where(x => x.MeasurementType == MeasurementType.HotWater)
                                   .Where(x => x.PlaceType == PlaceType.Bathroom)
                                   .ToList(),
            };
            if (check.BathroomHotWater.Count > 1)
            {
                var value1 = measurements
                                        .Where(x => x.PlaceType == PlaceType.Bathroom)
                                        .Where(x => x.MeasurementType == MeasurementType.HotWater)
                                        .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).First();
                var value2 = measurements
                                        .Where(x => x.PlaceType == PlaceType.Bathroom)
                                        .Where(x => x.MeasurementType == MeasurementType.HotWater)
                                        .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).Skip(1).First();

                var result = value1.Value - value2.Value;
                return result;
            }

            return 0;
        }

        private double ComputeBathroomColdWater()
        {
            var measurements = _context.Measurements;
            var check = new HomeIndexViewModel
            {
                BathroomColdWater = measurements
                                   .Where(x => x.MeasurementType == MeasurementType.ColdWater)
                                   .Where(x => x.PlaceType == PlaceType.Bathroom)
                                   .ToList(),
            };
            if (check.BathroomColdWater.Count > 1)
            {
                var value1 = measurements
                                    .Where(x => x.PlaceType == PlaceType.Bathroom)
                                    .Where(x => x.MeasurementType == MeasurementType.ColdWater)
                                    .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).First();
                var value2 = measurements
                                        .Where(x => x.PlaceType == PlaceType.Bathroom)
                                        .Where(x => x.MeasurementType == MeasurementType.ColdWater)
                                        .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).Skip(1).First();

                var result = value1.Value - value2.Value;

                return result;
            }
            return 0;
        }

        private double ComputeLivingRoom()
        {
            var measurements = _context.Measurements;
            var check = new HomeIndexViewModel
            {
                LivingRoom = measurements
                                     .Where(x => x.MeasurementType == MeasurementType.Heat)
                                     .Where(x => x.PlaceType == PlaceType.LivingRoom)
                                     .ToList(),
            };
            if (check.LivingRoom.Count > 1)
            {
                var value1 = measurements
                                    .Where(x => x.PlaceType == PlaceType.LivingRoom)
                                    .Where(x => x.MeasurementType == MeasurementType.Heat)
                                    .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).First();
                var value2 = measurements
                                        .Where(x => x.PlaceType == PlaceType.LivingRoom)
                                        .Where(x => x.MeasurementType == MeasurementType.Heat)
                                        .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).Skip(1).First();

                var result = value1.Value - value2.Value;

                return result;
            }
            return 0;
        }

        private double ComputeBedRoom()
        {
            var measurements = _context.Measurements;
            var check = new HomeIndexViewModel
            {
                BedRoom = measurements
                                     .Where(x => x.MeasurementType == MeasurementType.Heat)
                                     .Where(x => x.PlaceType == PlaceType.BedRoom)
                                     .ToList(),
            };
            if (check.BedRoom.Count > 1)
            {
                var value1 = measurements
                                    .Where(x => x.PlaceType == PlaceType.BedRoom)
                                    .Where(x => x.MeasurementType == MeasurementType.Heat)
                                    .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).First();
                var value2 = measurements
                                        .Where(x => x.PlaceType == PlaceType.BedRoom)
                                        .Where(x => x.MeasurementType == MeasurementType.Heat)
                                        .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).Skip(1).First();

                var result = value1.Value - value2.Value;

                return result;
            }
            return 0;
        }

        private double ComputeChildRoom()
        {
            var measurements = _context.Measurements;
            var check = new HomeIndexViewModel
            {
                ChildRoom = measurements
                                     .Where(x => x.MeasurementType == MeasurementType.Heat)
                                     .Where(x => x.PlaceType == PlaceType.ChildRoom)
                                     .ToList(),
            };
            if (check.ChildRoom.Count > 1)
            {
                var value1 = measurements
                                    .Where(x => x.PlaceType == PlaceType.ChildRoom)
                                    .Where(x => x.MeasurementType == MeasurementType.Heat)
                                    .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).First();
                var value2 = measurements
                                        .Where(x => x.PlaceType == PlaceType.ChildRoom)
                                        .Where(x => x.MeasurementType == MeasurementType.Heat)
                                        .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).Skip(1).First();

                var result = value1.Value - value2.Value;

                return result;
            }
            return 0;
        }

        private double ComputeCorridor()
        {
            var measurements = _context.Measurements;
            var check = new HomeIndexViewModel
            {
                Corridor = measurements
                                     .Where(x => x.MeasurementType == MeasurementType.Energy)
                                     .Where(x => x.PlaceType == PlaceType.Corridor)
                                     .ToList(),
            };
            if (check.Corridor.Count > 1)
            {
                var value1 = measurements
                                    .Where(x => x.PlaceType == PlaceType.Corridor)
                                    .Where(x => x.MeasurementType == MeasurementType.Energy)
                                    .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).First();
                var value2 = measurements
                                        .Where(x => x.PlaceType == PlaceType.Corridor)
                                        .Where(x => x.MeasurementType == MeasurementType.Energy)
                                        .Where(x => x.Value == x.Value).OrderByDescending(x => x.Date).Skip(1).First();

                var result = value1.Value - value2.Value;

                return result;
            }
            return 0;
        }
    }
}