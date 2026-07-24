using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Create
{
    public class ComentariosTicketsCreateDto
    {
        [Required(ErrorMessage = "El id del ticket es requerido")]
        public int? TicketId { get; set; }
        public int? UserId { get; set; }
        public string? Mensaje { get; set; }

        [Required(ErrorMessage = "La fecha del comentario es requerido")]
        public DateOnly FechaComentario { get; set; }
    }
}
