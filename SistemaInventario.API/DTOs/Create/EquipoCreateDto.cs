using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class EquipoCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Serial { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string TipoEquipo { get; set; } = string.Empty;

        [Required]
        public DateOnly FechaCompra { get; set; }
        public int? RentingId { get; set; }

        [Range(0, 120)]
        public int MesesGarantia { get; set; }
        public int ProveedorId { get; set; }
    }
}
