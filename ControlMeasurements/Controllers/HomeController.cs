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

            var cards = measurements
                                .GroupBy(x => x.MeasurementType)
                                .Select(g => new Card
                                {
                                    MeasurementType = g.Key,
                                    Subcards = g.GroupBy(x => x.PlaceType)
                                                .Select(sg => new Subcard
                                                {
                                                    PlaceType = sg.Key,
                                                    MeasurementViews = sg.OrderByDescending(k => k.Date)
                                                                         .Take(3)
                                                                         .Select(m => new MeasurementView
                                                                         {
                                                                             Measurement = m
                                                                         })
                                                                         .ToList()
                                                })
                                                .ToList()
                                })
                                .ToList();

            foreach (var measurement in cards)
            {
                foreach (var subcard in measurement.Subcards)
                {
                    for (int i = 0; i < subcard.MeasurementViews.Count - 1; i++)
                    {
                        subcard.MeasurementViews[i].Change = subcard.MeasurementViews[i].Measurement.Value - subcard.MeasurementViews[i + 1].Measurement.Value;
                    }
                }
            }
            return View(cards);
        }
    }
}