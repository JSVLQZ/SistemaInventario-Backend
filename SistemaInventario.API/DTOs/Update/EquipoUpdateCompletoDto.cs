using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Update
{
    public class EquipoUpdateCompletoDto
    {
        [Required(ErrorMessage = "El campo Serial es obligatorio.")]
        public string Serial { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Marca es obligatorio.")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Modelo es obligatorio.")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Tipo de Equipo es obligatorio.")]
        public string TipoEquipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Fecha de Compra es obligatorio.")]
        public DateOnly FechaCompra { get; set; }

        [Required(ErrorMessage = "El campo Meses de Garantía es obligatorio.")]
        public int MesesGarantia { get; set; }

        [Required(ErrorMessage = "El Proveedor es obligatorio.")]
        public int ProveedorId { get; set; }
    }
}
