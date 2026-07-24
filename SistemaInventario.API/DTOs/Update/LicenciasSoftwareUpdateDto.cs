using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Update
{
    public class LicenciasSoftwareUpdateDto
    {
        public string? NombreLicencia { get; set; }
        public string? TipoLicencia { get; set; }
    }
}
