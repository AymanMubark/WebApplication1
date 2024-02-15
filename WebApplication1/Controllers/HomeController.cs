using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebApplication1Context _context;

        public HomeController(WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var areas = _context.Areas.ToList();
            var units = _context.Units.ToList();

            var viewModel = new HomeViewModel
            {
                Areas = areas,
                Units = units
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult GetUnitsByArea(int areaId)
        {
            var units = _context.Units.Where(u => u.AreaId == areaId).ToList();
            return Json(units);
        }

        [HttpPost]
        public IActionResult GetLocationsByUnit(int unitId)
        {
            var locations = _context.Locations.Where(l => l.UnitId == unitId).ToList();
            return Json(locations);
        }
    }
}
