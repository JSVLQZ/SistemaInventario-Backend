using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class ComentariosTickets
    {
        [Column("comentario_id")]
        public int ComentarioId { get; set; }

        [Column("ticket_id")]
        public int TicketId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("mensaje")]
        public string? Mensaje { get; set; }

        [Column("fecha_comentario")]
        public DateOnly FechaComentario { get; set; }

        [ForeignKey("ticket_id")]
        public Tickets? Ticket { get; set; }

        [ForeignKey("user_id")]
        public Usuario? Usuario { get; set; }
    }
}
