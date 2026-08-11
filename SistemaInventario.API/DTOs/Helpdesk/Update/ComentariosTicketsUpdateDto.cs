using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Update
{
    public class ComentariosTicketsUpdateDto
    {
        [StringLength(1000)]
        public string? Mensaje { get; set; }
    }
}
