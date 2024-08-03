using System.ComponentModel.DataAnnotations;

namespace Web_App1.Models
{
    public class Distritos
    {
        [Required][Display(Name = "Codigo distrito")] public int idDistrito { get; set; }
        [Required][Display(Name = "Distrito")] public string nomDistrito { get; set; } = string.Empty;
    }
}
