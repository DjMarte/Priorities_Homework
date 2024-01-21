using System.ComponentModel.DataAnnotations;

namespace Priorities_Homework.Models
{
    public class Prioridad
    {
        [Key]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Descripción obligatoria")]
        public string? Descripción { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, 31, ErrorMessage = "Debe ingresar valores entre 1 y 31")]
        public int DiasCompromiso { get; set; }
    }
}