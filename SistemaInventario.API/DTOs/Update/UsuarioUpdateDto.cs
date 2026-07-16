using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Update
{
    public class UsuarioUpdateDto
    {
        public string? Nombre { get; set; }

        public string? Cargo { get; set; }
    }
}
