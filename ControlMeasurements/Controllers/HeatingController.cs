using ControlMeasurements.Data;
using ControlMeasurements.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ControlMeasurements.Controllers
{
    public class HeatingController : Controller
    {
        private MeasurementsContext _context;

        public HeatingController(MeasurementsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.HeatingMeasurements.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Place,Measurement")] HeatingMeasurement heating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(heating);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heatingMeasurement = await _context.HeatingMeasurements.SingleOrDefaultAsync(m => m.Id == id);
            if (heatingMeasurement == null)
            {
                return NotFound();
            }
            return View(heatingMeasurement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, [Bind("Id,Place,Measurement")] HeatingMeasurement heatingMeasurement)
        {
            if (Id != heatingMeasurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heatingMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeatingMeasurement(heatingMeasurement.Id))
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
            return View(heatingMeasurement);
        }

        private bool HeatingMeasurement(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var heatingMeasurement = await _context.HeatingMeasurements.SingleOrDefaultAsync(m => m.Id == id);
            if (heatingMeasurement == null)
            {
                return NotFound();
            }
            return View(heatingMeasurement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id, [Bind("Id,Place,Measurement")]HeatingMeasurement heatingMeasurement)
        {
            if (Id != heatingMeasurement.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(heatingMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeatingMeasurement(heatingMeasurement.Id))
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
            return View(heatingMeasurement);
        }
    }
}