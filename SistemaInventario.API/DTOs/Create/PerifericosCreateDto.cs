using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class PerifericosCreateDto
    {
        [Required]
        [StringLength(100)]
        public string SerialPeriferico { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string TipoPeriferico { get; set; } = string.Empty;
        public int? UsuarioId { get; set; }
    }
}
