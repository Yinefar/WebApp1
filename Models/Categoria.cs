
using System.ComponentModel.DataAnnotations;

namespace Web_App1.Models
{
    public class Categoria
    {
       [Required] [Display (Name ="IdCategoria")] public int IdCategoria { get; set; }
       [Required] [Display(Name = "Categoría")] public string NombreCategoria {  get; set; } = string.Empty;

    }
}
