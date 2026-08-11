using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class AsignacionEquiposCreateDto
    {
        public int EquipoId { get; set; }
        public int UsuarioId { get; set; }

        [StringLength(1000)]
        public string? Observaciones { get; set; }
    }
}
