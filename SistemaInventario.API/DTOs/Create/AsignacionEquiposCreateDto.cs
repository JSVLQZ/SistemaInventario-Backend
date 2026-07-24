using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class AsignacionEquiposCreateDto
    {
        [Required(ErrorMessage = "El ID del equipo es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del equipo debe ser valido.")]
        public int? EquipoId { get; set; }

        [Required(ErrorMessage = "El ID del usuario es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del usuario debe ser valido.")]
        public int? UsuarioId { get; set; }

        [Required(ErrorMessage = "La fecha de asignación es requerida.")]
        public DateTime FechaAsignacion { get; set; } = DateTime.Now;

        public string? Observaciones { get; set; }
    }
}
