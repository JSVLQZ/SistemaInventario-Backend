using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class LicenciasSoftware
    {
        [Column("licencia_id")]
        public int LicenciaId { get; set; }

        [Column("nombre_licencia")]
        public string NombreLicencia { get; set; } = string.Empty;

        [Column("clave_activacion")]
        public string ClaveActivacion { get; set; } = string.Empty;

        [Column("fecha_expiracion")]
        public DateOnly FechaExpiracion { get; set; }

        [Column("tipo_licencia")]
        public string TipoLicencia { get; set; } = string.Empty;

        [Column("equipo_id")]
        public int EquipoId { get; set; }

        [ForeignKey("equipo_id")]
        public Equipos? Equipo { get; set; }
    }
}
