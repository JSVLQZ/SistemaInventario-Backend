using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class ComponentesCreateDto
    {
        public int? EquipoId { get; set; }
        [Required]
        [StringLength(50)]
        public string TipoComponente { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        public string Detalles { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string SerialComponente { get; set; } = string.Empty;
    }
}
