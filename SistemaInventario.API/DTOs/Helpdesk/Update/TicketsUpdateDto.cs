using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Update
{
    public class TicketsUpdateDto
    {
        public int? CategoriaId { get; set; }

        [StringLength(1000)]
        public string? Descripcion { get; set; }
    }
}
