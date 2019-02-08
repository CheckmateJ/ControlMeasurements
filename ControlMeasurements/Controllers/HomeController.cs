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
        private MeasurementsContext _context;

        public HomeController(MeasurementsContext context)
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
                    if (!WaterMeasurement(waterMeasurement.Id))
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

        private bool WaterMeasurement(Guid id)
        {
            throw new NotImplementedException();
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
        public async Task<IActionResult> Delete (Guid Id,[Bind("Id,Place,Measurement")]WaterMeasurement waterMeasurement)
        {
            if(Id != waterMeasurement.Id)
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
                    if (!WaterMeasurement(waterMeasurement.Id))
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
    }

 }

    


