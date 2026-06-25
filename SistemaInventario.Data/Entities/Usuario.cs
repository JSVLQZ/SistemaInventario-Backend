using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Usuario
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("correo")]
        public string Correo { get; set; } = string.Empty;

        [Column("cargo")]
        public string Cargo { get; set; } = string.Empty;

        [Column("ubicacion_id")]
        public int UbicacionId { get; set; }

        [ForeignKey("ubicacion_id")]
        public Sedes Ubicacion { get; set; }
    }
}
