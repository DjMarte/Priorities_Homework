using System.ComponentModel.DataAnnotations;

namespace Priorities_Homework.Models
{
	public class Clientes
	{
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nombre obligatorio")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Solo se permiten letras")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Teléfono obligatorio")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "El número de teléfono debe contener al menos {2} dígitos y máximo {1} dígitos.")]

        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Celular obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        [StringLength(12,MinimumLength = 10, ErrorMessage = "El número de celular debe contener al menos {2} dígitos y máximo {1} dígitos.")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "RNC obligatorio")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "El RNC debe contener solo números.")]
		public string? RNC { get; set; }

        [Required(ErrorMessage = "Correo obligatorio")]
		[RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$", ErrorMessage = "Correo no válido. Ej: nombreusuario@dominio.com")]
		public string? Email { get; set; }

        [Required(ErrorMessage = "Dirección obligatoria")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Debe introducir una dirección real.")]
        public string? Direccion { get; set; }

    }
}
