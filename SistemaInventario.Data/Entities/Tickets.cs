using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Tickets
    {
        [Column("ticket_id")]
        public int TicketId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("equipo_id")]
        public int? EquipoId { get; set; }

        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [Column("titulo")]
        public string CategoriaName { get; set; } = string.Empty;

        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("estado")]
        public string Estado { get; set; } = string.Empty;

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("user_id")]
        public Usuario Usuario { get; set; }

        [ForeignKey("equipo_id")]
        public Equipos? Equipo { get; set; }

        [ForeignKey("categoria_id")]
        public CategoriaTicket Categoria { get; set; }
    }
}
