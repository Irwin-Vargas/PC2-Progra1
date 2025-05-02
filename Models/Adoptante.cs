using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace practica2.Models
{
    public class Adoptante
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public List<Adopcion>? Adopciones { get; set; }
    }
}