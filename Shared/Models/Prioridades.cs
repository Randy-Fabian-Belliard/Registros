using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrosWeb.Shared.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Es obligatorio tener una descripcion")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Es obligatorio tener dias compromiso")]

        [Range(0, 31, ErrorMessage = "Los dias deben estar entre {1} y {2}")]
        public int DiasCompromiso { get; set; }
    }
}
