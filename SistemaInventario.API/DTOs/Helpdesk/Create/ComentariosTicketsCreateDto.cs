using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Create
{
    public class ComentariosTicketsCreateDto
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Mensaje { get; set; } = string.Empty;
    }
}
