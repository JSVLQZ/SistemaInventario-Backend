using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class LicenciasSoftwareCreateDto
    {
        [Required]
        [StringLength(100)]
        public string NombreLicencia { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string ClaveActivacion { get; set; } = string.Empty;
        public DateOnly? FechaExpiracion { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoLicencia { get; set; } = string.Empty;
        public int? EquipoId { get; set; }
    }
}
