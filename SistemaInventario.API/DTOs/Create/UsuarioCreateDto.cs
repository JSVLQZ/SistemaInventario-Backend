using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Id de la ubicación es obligatorio")]
        public int UbicacionId { get; set; } 
    }
}
