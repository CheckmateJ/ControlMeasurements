using ControlMeasurements.Data;
using ControlMeasurements.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControlMeasurements.Controllers
{
    public class WaterController : Controller
    {
        private MeasurementsContext _context;

        public WaterController(MeasurementsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.WaterMeasurements.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Place,Measurement")] WaterMeasurement water)
        {
            if (ModelState.IsValid)
            {
                _context.Add(water);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(water);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeasurement = await _context.WaterMeasurements.SingleOrDefaultAsync(m => m.Id == id);
            if (waterMeasurement == null)
            {
                return NotFound();
            }
            return View(waterMeasurement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, [Bind("Id,Place,Measurement")] WaterMeasurement waterMeasurement)
        {
            if (Id != waterMeasurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waterMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exist(waterMeasurement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(waterMeasurement);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var waterMeasurement = await _context.WaterMeasurements.SingleOrDefaultAsync(m => m.Id == id);
            if (waterMeasurement == null)
            {
                return NotFound();
            }
            return View(waterMeasurement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id, [Bind("Id,Place,Measurement")]WaterMeasurement waterMeasurement)
        {
            if (Id != waterMeasurement.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(waterMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exist(waterMeasurement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(waterMeasurement);
        }

        private bool Exist(Guid id)
        {
            return _context.WaterMeasurements.Any(x => x.Id == id);
        }
    }
}