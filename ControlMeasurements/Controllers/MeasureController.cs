using ControlMeasurements.Data;
using ControlMeasurements.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControlMeasurements.Controllers
{
    public class MeasureController : Controller
    {
        private MeasurementsContext _context;

        public MeasureController(MeasurementsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Measurements.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceType,MeasurementType,Value")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(measurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measurement);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurement = await _context.Measurements.SingleOrDefaultAsync(m => m.Id == id);
            if (measurement == null)
            {
                return NotFound();
            }
            return View(measurement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, [Bind("Id,PlaceType,MeasurementType,Value")] Measurement measurement)
        {
            if (Id != measurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exist(measurement.Id))
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
            return View(measurement);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var measurement = await _context.Measurements.SingleOrDefaultAsync(m => m.Id == id);
            if (measurement == null)
            {
                return NotFound();
            }
            return View(measurement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id, [Bind("Id,PlaceType,MeasurementType,Value")]Measurement measurement)
        {
            if (Id != measurement.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(measurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exist(measurement.Id))
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
            return View(measurement);
        }

        private bool Exist(Guid id)
        {
            return _context.Measurements.Any(x => x.Id == id);
        }
    }
}