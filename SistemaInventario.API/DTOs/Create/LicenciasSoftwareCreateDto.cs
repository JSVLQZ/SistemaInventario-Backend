using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class LicenciasSoftwareCreateDto
    {
        [Required(ErrorMessage = "El nombre de la licencia es requerido")]
        public string NombreLicencia { get; set; } = null!;
        [Required(ErrorMessage = "La clave de activación es requerida")]
        public string ClaveActivacion { get; set; } = null!;

        [Required(ErrorMessage = "La fecha de expiración es requerida")]
        public DateOnly? FechaExpiracion { get; set; }
        [Required(ErrorMessage = "El tipo de licencia es requerido")]
        public string TipoLicencia { get; set; } = null!;
        public int? EquipoId { get; set; }
    }
}
