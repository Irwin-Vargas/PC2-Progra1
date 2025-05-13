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
    public class AdoptantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdoptantesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Adoptante adoptante)
        {
            if (!ModelState.IsValid)
                return View(adoptante);

            _context.Adoptantes.Add(adoptante);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}