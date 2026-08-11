using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Tickets
    {
        [Key]
        [Column("ticket_id")]
        public int TicketId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("equipo_id")]
        public int? EquipoId { get; set; }

        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [Column("titulo")]
        public string? Titulo { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; } = null;

        [Column("estado")]
        public string Estado { get; set; } = string.Empty;

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("EquipoId")]
        public Equipos? Equipo { get; set; }

        [ForeignKey("CategoriaId")]
        public CategoriaTicket? Categoria { get; set; }
    }
}
