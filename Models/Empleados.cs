using System.ComponentModel.DataAnnotations;

namespace Web_App1.Models
{
    public class Empleados
    {
        [Required][Display(Name = "Id empleado")] public int IdEmpleado { get; set; }
        [Required][Display(Name = "Apellido")] public string ApeEmpleado { get; set; } = string.Empty;
        [Required][Display(Name = "Nombre")] public string NomEmpleado { get; set; } = string.Empty;
        [Required][Display(Name = "Fecha nacimiento")] public DateTime FecNac { get; set; }
        [Required][Display(Name = "Dirección")] public string DirEmpleado { get; set; } = string.Empty;
        [Required][Display(Name = "Distrito")] public string nomDistrito { get; set; } = string.Empty;
        [Required][Display(Name = "Teléfono")] public string fonoEmpleado { get; set; } = string.Empty;
        [Required][Display(Name = "Cargo")] public string desCargo { get; set; } = string.Empty;
        [Required][Display(Name = "Fecha de contrato")] public DateTime fecContrata { get; set; }
    }
}