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
            return View();
        }

    }
}
