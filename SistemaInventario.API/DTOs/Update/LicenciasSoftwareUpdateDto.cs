using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Update
{
    public class LicenciasSoftwareUpdateDto
    {
        [StringLength(100)]
        public string? NombreLicencia { get; set; }
        public DateOnly? FechaExpiracion { get; set; }

        [StringLength(50)]
        public string? TipoLicencia { get; set; }
        public int? EquipoId { get; set; }
    }
}
