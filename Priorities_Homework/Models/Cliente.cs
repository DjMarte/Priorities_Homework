using System.ComponentModel.DataAnnotations;

namespace Priorities_Homework.Models
{
	public class Cliente
	{
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nombre obligatorio")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Solo se permiten letras")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Teléfono obligatorio")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten numeros")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "El número de teléfono debe contener al menos {2} dígitos y maximo {1} dígitos.")]

        public string? Teléfono { get; set; }

        [Required(ErrorMessage = "Celular obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten numeros")]
        [StringLength(12,MinimumLength = 10, ErrorMessage = "El número de celular debe contener al menos {2} dígitos y maximo {1} dígitos.")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "RNC obligatorio")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "El RNC debe contener solo numeros.")]
		public string? RNC { get; set; }

        [Required(ErrorMessage = "Correo obligatorio")]
		[RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$", ErrorMessage = "Correo no válido. Ej: nombreusuario@dominio.com")]
		public string? Email { get; set; }

        [Required(ErrorMessage = "Dirección obligatoria")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Debe introducir una direccion real.")]
        public string? Dirección { get; set; }

    }
}
