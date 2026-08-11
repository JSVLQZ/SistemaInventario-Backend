using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaInventario.Data.Entities
{
    public class Perifericos
    {
        [Key]
        [Column("periferico_id")]
        public int PerifericoId { get; set; }

        [Column("serial_periferico")]
        public string SerialPeriferico { get; set; } = string.Empty;

        [Column("marca")]
        public string Marca { get; set; } = string.Empty;

        [Column("modelo")]
        public string Modelo { get; set; } = string.Empty;

        [Column("tipo_periferico")]
        public string TipoPeriferico { get; set; } = string.Empty;

        [Column("user_id")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set; }
    }
}
