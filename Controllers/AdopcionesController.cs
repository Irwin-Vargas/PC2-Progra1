using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using practica2.Data;
using practica2.Models;

namespace practica2.Controllers
{
    public class AdopcionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdopcionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Mascotas = _context.Mascotas
            .Where(m=> !m.EstaAdoptada)
            .ToList();
            ViewBag.Adoptantes = _context.Adoptantes.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Crear(int mascotaId, int adoptanteId)
        {
            var adopcion = new Adopcion 
            {
                MascotaId = mascotaId,
                AdoptanteId = adoptanteId,
                FechaAdopcion = DateTime.UtcNow,
            };
            var mascota = _context.Mascotas.Find(mascotaId);
            if (mascota != null) mascota.EstaAdoptada = true;
            _context.Adopciones.Add(adopcion);
            _context.SaveChanges();

            return RedirectToAction("Listado");
        }

        public IActionResult Listado()
        {
            var adopciones = _context.Adopciones
            .Include(a => a.Mascota)
            .Include(a => a.Adoptante)
            .ToList();

            return View(adopciones);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}