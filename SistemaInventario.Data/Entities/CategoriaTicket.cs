using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class CategoriaTicket
    {
        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [Column("nombre_categoria")]
        public string NombreCategoria { get; set; } = string.Empty;
    }
}
