using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class ComponentesCreateDto
    {
        public int? EquipoId { get; set; }

        [Required(ErrorMessage = "El tipo de componente debe ser especificado")]
        public string TipoComponente { get; set; } = string.Empty;
        public string? Detalles { get; set; }
        [Required(ErrorMessage = "El serial del componente debe ser especificado")]
        public string SerialComponente { get; set; } = null!;
    }
}
