using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Update
{
    public class CategoriaTicketUpdateDto
    {
        [StringLength(100)]
        public string? NombreCategoria { get; set; }
    }
}
