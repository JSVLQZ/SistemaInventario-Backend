using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class ProveedorCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El NIT es obligatorio")]
        public string Nit { get; set; } = string.Empty;

        [Required(ErrorMessage = "El contacto de soporte es obligatorio")]
        public string ContactoSoporte { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono no es válido")]
        public string? Telefono { get; set; }
    }
}
