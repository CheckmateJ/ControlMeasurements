using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlMeasurements.Data;
using Microsoft.AspNetCore.Mvc;

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

            PlaceType measure = Convert.ToString(Enum.PlaceType);
            var querry = _context.Measurements.Select(n => n).ToList();
            return View(querry);
            
        }
    }
}