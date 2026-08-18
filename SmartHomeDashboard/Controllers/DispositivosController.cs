using Microsoft.AspNetCore.Mvc;
using SmartHomeDashboard.Data;
using SmartHomeDashboard.Models;

namespace SmartHomeDashboard.Controllers
{
    public class DispositivosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DispositivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dispositivos = _context.Dispositivos.ToList();

            return View(dispositivos);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
              dispositivo.UltimaComunicacao = DateTime.Now;

              _context.Dispositivos.Add(dispositivo);
              _context.SaveChanges();

              return RedirectToAction("Index");
          }

            return View(dispositivo);
        }
   

        // EDITAR DISPOSITIVO
        public IActionResult Edit(int id)
                {
            var dispositivo = _context.Dispositivos.Find(id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            return View(dispositivo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                dispositivo.UltimaComunicacao = DateTime.Now;

                _context.Dispositivos.Update(dispositivo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(dispositivo);
        }
        public IActionResult Delete(int id)
        {
            var dispositivo = _context.Dispositivos.Find(id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            return View(dispositivo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var dispositivo = _context.Dispositivos.Find(id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            _context.Dispositivos.Remove(dispositivo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    } // final do DispositivosController

}


