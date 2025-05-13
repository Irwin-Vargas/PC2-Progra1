using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practica2.Models
{
    public class Adopcion
    {
        public int Id { get; set; }

        [ForeignKey("Mascota")]
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }

        [ForeignKey("Adoptante")]
        public int AdoptanteId { get; set; }
        public Adoptante Adoptante { get; set; }

        public DateTime FechaAdopcion { get; set; } = DateTime.Now;
    }
}