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
            };
            return View(result);
        }
    }
}