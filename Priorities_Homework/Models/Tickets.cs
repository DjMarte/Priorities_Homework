using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Priorities_Homework.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        public DateTime Tiempo { get; set; }

        [ForeignKey("ClienteId")]
        [Required(ErrorMessage = "Se necesita ID del cliente")]

        public int ClienteId { get; set; }

        [ForeignKey("PrioridadId")]
        [Required(ErrorMessage = "Se necesita ID de la prioridad")]

        public int PrioridadId { get; set; }

        [ForeignKey("SistemaId")]
        [Required(ErrorMessage = "Se necesita ID del sistema")]

        public int SistemaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string? Descripcion { get; set; }

    }
}
