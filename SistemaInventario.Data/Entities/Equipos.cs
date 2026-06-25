using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Equipos
    {
        [Column("equipo_id")]
        public int EquipoId { get; set; }

        [Column("serial")]
        public string Serial { get; set; } = string.Empty;

        [Column("marca")]
        public string Marca { get; set; } = string.Empty;

        [Column("modelo")]
        public string Modelo { get; set; } = string.Empty;

        [Column("tipo_equipo")]
        public string TipoEquipo { get; set; } = string.Empty;

        [Column("estado")]
        public string Estado { get; set; } = string.Empty;

        [Column("fecha_compra")]
        public DateOnly FechaCompra { get; set; }

        [Column("renting_id")]
        public int? RentingId { get; set; }

        [Column("meses_garantia")]
        public int MesesGarantia { get; set; }

        [Column("proveedor_id")]
        public int ProveedorId { get; set; }

        [ForeignKey("renting_id")]
        public Renting? Renting { get; set; }

        [ForeignKey("proveedor_id")]
        public Proveedores Proveedor { get; set; }
    }
}
