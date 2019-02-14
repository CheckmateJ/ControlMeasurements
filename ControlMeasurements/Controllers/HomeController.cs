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
                WaterMeasurements = measurements
                                    .Where(x => x.MeasurementType == MeasurementType.Water).OrderByDescending(x => x.Id).Take(3)
                                    .ToList(),
                HeatMeasurements = measurements
                                   .Where(x => x.MeasurementType == MeasurementType.Heat).OrderByDescending(x => x.Id).Take(3)
                                   .ToList(),
                EnergyMeasurements = measurements
                                     .Where(x => x.MeasurementType == MeasurementType.Energy).OrderByDescending(x => x.Id
                                     ).Take(3)
                                     .ToList(),
            };
            return View(result);
        }
    }
}