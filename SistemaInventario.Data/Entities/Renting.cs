using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Renting
    {
        [Key]
        [Column("renting_id")]
        public int RentingId { get; set; }

        [Column("empresa_renting")]
        public string EmpresaRenting { get; set; } = string.Empty;

        [Column("fecha_inicio")]
        public DateOnly FechaInicio { get; set; }

        [Column("fecha_fin")]
        public DateOnly FechaFin { get; set; }

        [Column("pago_mensual")]
        public decimal PagoMensual { get; set; }
    }
}
