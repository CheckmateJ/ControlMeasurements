using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlMeasurements.Data;
using ControlMeasurements.ViewModels;
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

            var model = new HomeIndexViewModel();

            return (model);
            
        }
    }
}