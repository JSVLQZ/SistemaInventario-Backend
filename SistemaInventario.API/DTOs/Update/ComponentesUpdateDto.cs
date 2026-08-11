using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Update
{
    public class ComponentesUpdateDto
    {
        public int? EquipoId { get; set; }

        [StringLength(50)]
        public string? TipoComponente { get; set; } 

        [StringLength(255)]
        public string? Detalles { get; set; } 
    }
}
