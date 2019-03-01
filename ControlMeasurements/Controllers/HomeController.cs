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

            var measurementViews = measurements
                                    .GroupBy(x => new
                                    {
                                        x.MeasurementType,
                                        x.PlaceType
                                    }) // group by measurement type
                                    .Select(g => new MeasurementViewModel // create a new MeasurementViewModel from each group
                                    {
                                        MeasurementType = g.Key.MeasurementType,
                                        PlaceType = g.Key.PlaceType,
                                        MeasurementViews = g.OrderByDescending(x => x.Date)
                                                            .Take(3) // take three most recent measurements
                                                            .Select(x => new MeasurementView // create a new MeasurementView from every Measurement (without "Change" field for now)
                                                            {
                                                                Measurement = x
                                                            })
                                                            .ToList(),
                                    }).ToList();

            foreach (var measurementView in measurementViews)
            {
                for (int i = 0; i < measurementView.MeasurementViews.Count - 1; i++) // calculate the change for all measurements without the last one
                {
                    measurementView.MeasurementViews[i].Change = measurementView.MeasurementViews[i].Measurement.Value - measurementView.MeasurementViews[i + 1].Measurement.Value;
                }
            }

            return View(measurementViews);
        }
    }
}