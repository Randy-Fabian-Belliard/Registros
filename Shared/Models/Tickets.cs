using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrosWeb.Shared.Models
{
    public class Tickets
    {
        [Key]

        public int TicketsId { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public int SistemaId { get; set; }
        [Required(ErrorMessage = "Este campo necesario")]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "Este campo")]
        public string? Descripcion { get; set; }
    }
}
