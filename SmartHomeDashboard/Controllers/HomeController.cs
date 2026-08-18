using Microsoft.AspNetCore.Mvc;
using SmartHomeDashboard.Data;
using SmartHomeDashboard.Models;
using SmartHomeDashboard.Services;
using System.Diagnostics;

namespace SmartHomeDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ClimaService _climaService;

        public HomeController(
            ApplicationDbContext context,
            ClimaService climaService)
        {
            _context = context;
            _climaService = climaService;
        }

        public async Task<IActionResult> Index()
        {
            var dispositivos = _context.Dispositivos.ToList();

            var clima = await _climaService.ObterClimaAsync();

            ViewBag.Clima = clima;

            return View(dispositivos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier
            });
        }
    }
}