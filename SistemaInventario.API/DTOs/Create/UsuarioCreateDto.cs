using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class UsuarioCreateDto
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Cargo { get; set; } = string.Empty;
        public int? UbicacionId { get; set; } 
    }
}
