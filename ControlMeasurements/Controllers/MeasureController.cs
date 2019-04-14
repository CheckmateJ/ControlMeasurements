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

        public async Task<IActionResult> Index(string sortOrder, int? page)
        {
            ViewBag.PlaceSortParm = String.IsNullOrEmpty(sortOrder) ? "PlaceType" : "";
            ViewBag.MeasurementType = sortOrder == "MeasurementType" ? "MeasurementType_desc" : "MeasurementType";
            ViewBag.ValueSortParm = sortOrder == "Value" ? "Value_desc" : "Value";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            var measurement = from m in _context.Measurements
                              select m;
            switch (sortOrder)
            {
                case "PlaceType":
                    measurement = measurement.OrderByDescending(s => s.PlaceType);
                    break;

                case "MeasurementType":
                    measurement = measurement.OrderBy(s => s.MeasurementType);
                    break;

                case "MeasurementType_desc":
                    measurement = measurement.OrderByDescending(s => s.MeasurementType);
                    break;

                case "Value":
                    measurement = measurement.OrderBy(s => s.Value);
                    break;

                case "Value_desc":
                    measurement = measurement.OrderByDescending(s => s.Value);
                    break;

                case "Date":
                    measurement = measurement.OrderBy(s => s.Date);
                    break;

                case "Date_desc":
                    measurement = measurement.OrderByDescending(s => s.Date);
                    break;

                default:
                    measurement = measurement.OrderBy(s => s.PlaceType);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Measurement>.CreateAsync(measurement.AsNoTracking(), page ?? 1, pageSize));
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