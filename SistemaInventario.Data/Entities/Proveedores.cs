using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Proveedores
    {
        [Key]
        [Column("proveedor_id")]
        public int ProveedorId { get; set; }

        [Column("nombre_empresa")]
        public string NombreEmpresa { get; set; } = string.Empty;

        [Column("nit")]
        public string Nit { get; set; } = string.Empty;

        [Column("contacto_soporte")]
        public string CorreoSoporte { get; set; } = string.Empty;

        [Column("telefono")]
        public string? Telefono { get; set; } 
    }
}
