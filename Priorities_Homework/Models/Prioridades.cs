using System.ComponentModel.DataAnnotations;

namespace Priorities_Homework.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Descripcion obligatoria")]
        public string? Descripción { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int DiasCompromiso { get; set; }



    }
}
