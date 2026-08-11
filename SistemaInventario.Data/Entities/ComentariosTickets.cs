using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    [Table("comentarios_tickets")]
    public class ComentariosTickets
    {
        [Key]
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

        [ForeignKey("TicketId")]
        public Tickets? Ticket { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set; }
    }
}
