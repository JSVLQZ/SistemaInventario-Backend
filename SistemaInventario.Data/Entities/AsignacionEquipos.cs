using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class AsignacionEquipos
    {
        [Column("asignacion_id")]
        public int AsignacionId { get; set; }

        [Column("equipo_id")]
        public int? EquipoId { get; set; } 

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("fecha_asignacion")]
        public DateTime FechaAsignacion { get; set; }

        [Column("observaciones")]
        public string? Observaciones { get; set; }

        [ForeignKey("equipo_id")]
        public Equipos? Equipos { get; set; }

        [ForeignKey("user_id")]
        public Usuario? Usuario { get; set; }
    }
}
