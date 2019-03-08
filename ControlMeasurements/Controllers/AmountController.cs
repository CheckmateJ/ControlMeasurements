using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlMeasurements.Data;
using ControlMeasurements.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlMeasurements.Controllers
{
    public class AmountController : Controller
    {
        private MeasurementsContext _context;

        public AmountController(MeasurementsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Amounts.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Price")] Amount amount)
        {
            if (ModelState.IsValid)
            {

                _context.Add(amount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amount);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amount = await _context.Amounts.SingleOrDefaultAsync(m => m.Id == id);
            if (amount == null)
            {
                return NotFound();
            }
            return View(amount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, [Bind("Id,Price")] Amount amount)
        {
            if (Id != amount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exist(amount.Id))
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
            return View(amount);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var amount = await _context.Amounts.SingleOrDefaultAsync(m => m.Id == id);
            if (amount == null)
            {
                return NotFound();
            }
            return View(amount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id, [Bind("Id,Price")]Amount amount)
        {
            if (Id != amount.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(amount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exist(amount.Id))
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
            return View(amount);
        }

        private bool Exist(Guid id)
        {
            return _context.Amounts.Any(x => x.Id == id);
        }
    
    }
}