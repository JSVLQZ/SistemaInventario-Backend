using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    [Table("historico_asignaciones")]
    public class HistoricoAsignaciones
    {
        [Key]
        [Column("historial_id")]
        public int HistorialId { get; set; }

        [Column("equipo_id")]
        public int EquipoId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("fecha_entrega")]
        public DateTime FechaEntrega { get; set; }

        [Column("fecha_recibido")]
        public DateTime? FechaRecibido { get; set; }

        [ForeignKey("EquipoId")]
        public Equipos? Equipo { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set; }
    }
}
