using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Data.Entities
{
    [Table("categoria_ticket")]
    public class CategoriaTicket
    {
        [Key]
        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [Column("nombre_categoria")]
        public string NombreCategoria { get; set; } = string.Empty;
    }
}
