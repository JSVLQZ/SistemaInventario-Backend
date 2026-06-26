using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
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

        [Column("fecha_devolucion")]
        public DateTime FechaDevolucion { get; set; }

        [Column("fecha_recibido")]
        public DateTime FechaRecibido { get; set; }
    }
}
