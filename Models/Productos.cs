using System.ComponentModel.DataAnnotations;

namespace Web_App1.Models
{
    public class Productos
    {
        [Required] [Display(Name = "Id de producto")] public int IdProducto { get; set; }
        [Required] [Display(Name = "Producto")] public string NomProducto { get; set; } = string.Empty;
        [Required] [Display(Name = "Proveedor")] public string NomProveedor { get; set; } = string.Empty;
        [Required][Display(Name = "Categoría")] public string NombreCategoria { get; set; } = string.Empty;
        [Required] [Display(Name = "Cantidad unidades")]  public string CantxUnidad { get; set; } = string.Empty;
        [Required] [Display(Name = "Precio unitario")] public decimal PrecioUnidad { get; set; }
        [Required] [Display(Name = "Unidades en existencia")] public short UnidadesEnExistencia { get; set; }
        [Required] [Display(Name = "Unidades en pedido")] public short UnidadesEnPedido { get; set; }

    }
}

