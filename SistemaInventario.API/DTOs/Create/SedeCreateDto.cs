using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class SedeCreateDto
    {
        [Required]
        [StringLength(45)]
        public string NombreSede { get; set; } = string.Empty;

        [StringLength(45)]
        public string? Piso { get; set; }

        [Required]
        [StringLength(45)]
        public string Ciudad { get; set; } = string.Empty;
    }
}
