using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    [Table("asignacion_equipos")]
    public class AsignacionEquipos
    {
        [Key]
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

        [ForeignKey("EquipoId")]
        public Equipos? Equipos { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set; }
    }
}
