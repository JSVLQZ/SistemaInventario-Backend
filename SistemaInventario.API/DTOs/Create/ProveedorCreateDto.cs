using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class ProveedorCreateDto
    {
        [Required]
        [StringLength(150)]
        public string NombreEmpresa { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nit { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CorreoSoporte { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Telefono { get; set; }
    }
}
