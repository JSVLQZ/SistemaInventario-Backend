using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class SedeCreateDto
    {
        [Required(ErrorMessage = "El nombre de la sede es requerido")]
        public string NombreSede { get; set; } = string.Empty;

        [Required(ErrorMessage = "El piso es requerido")]
        public string Piso { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es requerida")]
        public string Ciudad { get; set; } = string.Empty;
    }
}
