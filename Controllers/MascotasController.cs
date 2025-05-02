using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practica2.Data;
using practica2.Models;

namespace practica2.Controllers
{
    public class MascotasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MascotasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Mascotas/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Mascotas/Create")]
        public IActionResult Create(Mascota mascota)
        {
            if (!ModelState.IsValid)
                return View(mascota);

            _context.Mascotas.Add(mascota);
            _context.SaveChanges();

            return RedirectToAction("Create");
        }

        // Si no usas esta acción, elimínala o agrega un atributo
        [HttpGet("Mascotas/Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
