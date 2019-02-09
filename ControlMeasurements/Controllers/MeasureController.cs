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
            return View(await _context.MeasurementsCategory.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Place,Measurement")] MeasurementCategory measure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measure);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurementCategory = await _context.MeasurementsCategory.SingleOrDefaultAsync(m => m.Id == id);
            if (measurementCategory == null)
            {
                return NotFound();
            }
            return View(measurementCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, [Bind("Id,Place,Measurement")] MeasurementCategory measurementCategory)
        {
            if (Id != measurementCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurementCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exist(measurementCategory.Id))
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
            return View(measurementCategory);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var measurementCategory = await _context.MeasurementsCategory.SingleOrDefaultAsync(m => m.Id == id);
            if (measurementCategory == null)
            {
                return NotFound();
            }
            return View(measurementCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id, [Bind("Id,Place,Measurement")]MeasurementCategory measurementCategory)
        {
            if (Id != measurementCategory.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(measurementCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exist(measurementCategory.Id))
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
            return View(measurementCategory);
        }

        private bool Exist(Guid id)
        {
            return _context.MeasurementsCategory.Any(x => x.Id == id);
        }
    }
}