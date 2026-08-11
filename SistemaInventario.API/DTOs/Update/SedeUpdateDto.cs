using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Update
{
    public class SedeUpdateDto
    {
        [StringLength(45)]
        public string? NombreSede { get; set; }

        [StringLength(45)]
        public string? Piso { get; set; }
    }
}
