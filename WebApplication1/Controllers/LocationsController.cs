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
    public class LocationsController : Controller
    {
        private readonly WebApplication1Context _context;

        public LocationsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var webApplication1Context = _context.Locations.Include(l => l.Area).Include(l => l.Unit);
            return View(await webApplication1Context.ToListAsync());
        }

        

        // GET: Locations/Create
        public IActionResult Create()
        {
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitId,AreaId,Rating")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");

            return View(location);
        }

        [HttpGet]
        public IActionResult GetAreas(int unitId)
        {
            var areas = _context.AreaUnits
                .Where(au => au.UnitId == unitId)
                .Select(au => new SelectListItem { Value = au.Area.Id.ToString(), Text = au.Area.Name })
                .ToList();

            return Json(areas);
        }

    }
}
