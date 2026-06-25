using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Renting
    {
        [Column("renting_id")]
        public int RentingId { get; set; }

        [Column("empresa_renting")]
        public string EmpresaRenting { get; set; } = string.Empty;

        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        [Column("fecha_fin")]
        public DateTime FechaFin { get; set; }

        [Column("pago_mensual")]
        public decimal PagoMensual { get; set; }
    }
}
