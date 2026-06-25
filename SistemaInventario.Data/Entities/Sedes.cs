using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Sedes
    {
        [Column("ubicacion_id")]
        public int UbicacionId { get; set; }

        [Column("nombre_sede")]
        public string NombreSede { get; set; } = string.Empty;

        [Column("piso")]
        public string? Piso { get; set; }

        [Column("ciudad")]
        public string Ciudad { get; set; } = string.Empty;
    }
}
