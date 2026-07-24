using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class PerifericosCreateDto
    {
        [Required(ErrorMessage = "El serial del periférico es requerido")]
        public string SerialPeriferico { get; set; } = null!;
        [Required(ErrorMessage = "La marca del periferico es requerida")]
        public string Marca { get; set; } = null!;
        [Required(ErrorMessage = "El modelo del periferico es requerido")]
        public string Modelo { get; set; } = null!;
        [Required(ErrorMessage = "El tipo del periferico es requerido")]
        public string TipoPeriferico { get; set; } = null!;
        public int? UsuarioId { get; set; }
    }
}
