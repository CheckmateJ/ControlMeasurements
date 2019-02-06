using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControlMeasurements.Models;
using ControlMeasurements.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlMeasurements.Controllers
{
    public class HomeController : Controller
    {
        private WaterContext _context;

        public HomeController(WaterContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Waters.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Place,Measurement")] Water water)
        {
            if (ModelState.IsValid)
            {
                _context.Add(water);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(water);
        }
    }

}
