using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Update
{
    public class ProveedorUpdateDto
    {
        [StringLength(100)]
        [EmailAddress]
        public string? CorreoSoporte { get; set; }

        [StringLength(50)]
        public string? Telefono { get; set; }
    }
}
