using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AreaUnitsController : Controller
    {
        private readonly WebApplication1Context _context;

        public AreaUnitsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: AreaUnits
        public async Task<IActionResult> Index()
        {
            var webApplication1Context = _context.AreaUnits.Include(a => a.Area).Include(a => a.Unit);
            return View(await webApplication1Context.ToListAsync());
        }

        // GET: AreaUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AreaUnits == null)
            {
                return NotFound();
            }

            var areaUnit = await _context.AreaUnits
                .Include(a => a.Area)
                .Include(a => a.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaUnit == null)
            {
                return NotFound();
            }

            return View(areaUnit);
        }

        // GET: AreaUnits/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
            return View();
        }

        // POST: AreaUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnitId,AreaId")] AreaUnit areaUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name", areaUnit.AreaId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", areaUnit.UnitId);
            return View(areaUnit);
        }

        // GET: AreaUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AreaUnits == null)
            {
                return NotFound();
            }

            var areaUnit = await _context.AreaUnits.FindAsync(id);
            if (areaUnit == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name", areaUnit.AreaId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", areaUnit.UnitId);
            return View(areaUnit);
        }

        // POST: AreaUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnitId,AreaId")] AreaUnit areaUnit)
        {
            if (id != areaUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaUnitExists(areaUnit.Id))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name", areaUnit.AreaId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", areaUnit.UnitId);
            return View(areaUnit);
        }

        // GET: AreaUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AreaUnits == null)
            {
                return NotFound();
            }

            var areaUnit = await _context.AreaUnits
                .Include(a => a.Area)
                .Include(a => a.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaUnit == null)
            {
                return NotFound();
            }

            return View(areaUnit);
        }

        // POST: AreaUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AreaUnits == null)
            {
                return Problem("Entity set 'WebApplication1Context.AreaUnits'  is null.");
            }
            var areaUnit = await _context.AreaUnits.FindAsync(id);
            if (areaUnit != null)
            {
                _context.AreaUnits.Remove(areaUnit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaUnitExists(int id)
        {
          return (_context.AreaUnits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
