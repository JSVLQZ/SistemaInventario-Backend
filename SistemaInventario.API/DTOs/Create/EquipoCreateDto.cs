using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class EquipoCreateDto
    {
        [Required(ErrorMessage = "El serial es obligatorio")]
        public string Serial { get; set; } = string.Empty;

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de equipo es obligatorio")]
        public string TipoEquipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; } = string.Empty;
        public DateOnly FechaCompra { get; set; }
        public int MesesGarantia { get; set; }

        [Required(ErrorMessage = "El proveedor es obligatorio")]
        public int proveedorId { get; set; }
    }
}
