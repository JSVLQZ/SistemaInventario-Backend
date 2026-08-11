using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Update
{
    public class UsuarioUpdateDto
    {
        [StringLength(50)]
        public string? Nombre { get; set; }

        [StringLength(50)]
        public string? Cargo { get; set; }
        public int? UbicacionId { get; set; }
    }
}
