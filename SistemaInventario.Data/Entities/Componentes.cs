using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Componentes
    {
        [Key]
        [Column("componentes_id")]
        public int ComponentesId { get; set; }

        [Column("equipo_id")]
        public int? EquipoId { get; set; }

        [Column("tipo_componente")]
        public string TipoComponente { get; set; } = string.Empty;

        [Column("detalles")]
        public string? Detalles { get; set; }

        [Column("serial_componente")]
        public string SerialComponente { get; set; } = string.Empty;

        [ForeignKey("EquipoId")]
        public Equipos? Equipos { get; set; }
    }
}
