using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace practica2.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Range(0, 100)]
        public int Edad { get; set; }

        [Required]
        public string Tipo { get; set; }

        public bool EstaAdoptada { get; set; }

        public Adopcion? Adopcion { get; set; }
    }
}