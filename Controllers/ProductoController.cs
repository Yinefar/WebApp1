using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Web_App1.Models;

namespace Web_App1.Controllers
{
    public class ProductoController : Controller
    {
        public readonly IConfiguration _configuration;
        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        IEnumerable<Categoria> listaCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection cn = new(_configuration["ConnectionStrings:DBcx"]))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarCategorias", cn);
                cn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lista.Add(new Categoria
                    {
                        IdCategoria = r.GetInt32(0),
                        NombreCategoria = r.GetString(1),
                    });
                }
            }
            return lista;
        }



        IEnumerable<Productos> listaProductosCategoria(string NomProducto, int IdCategoria)
        {
            List<Productos> lista = new List<Productos>();
            using (SqlConnection cn = new(_configuration["ConnectionStrings:DBcx"]))
            {
                SqlCommand cmd = new SqlCommand("usp_ProductoCategoria", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomProducto", NomProducto);
                cmd.Parameters.AddWithValue("@idCategoria", IdCategoria);
                cn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lista.Add(new Productos
                    {
                        IdProducto = r.GetInt32(0),
                        NomProducto = r.GetString(1),
                        NomProveedor = r.GetString(2),
                        NombreCategoria = r.GetString(3),
                        CantxUnidad = r.GetString(4),
                        PrecioUnidad = r.GetDecimal(5),
                        UnidadesEnExistencia = r.GetInt16(6),
                        UnidadesEnPedido = r.GetInt16(7)
                    });
                }
                cn.Close();
            }
            return lista;
        }

        public async Task<IActionResult> IndexProductoCategoria(string NomProducto = "", int IdCategoria = 0, int pa = 0)
        {
            if (NomProducto == null)
            {
                NomProducto = string.Empty;
            }

            ViewBag.IdCategoria = IdCategoria;
            ViewBag.NomProducto = NomProducto;
            ViewBag.Categoria = new SelectList(listaCategorias(), "IdCategoria", "NombreCategoria");

            int filas = 5;
            var listaCompleta = listaProductosCategoria(NomProducto, IdCategoria).ToList();
            int n = listaCompleta.Count();
            int pags = n % filas > 0 ? n / filas + 1 : n / filas;

            ViewBag.pags = pags;
            ViewBag.pa = pa;

            var productosPaginados = listaCompleta.Skip(pa * filas).Take(filas).ToList();

            return View(await Task.FromResult(productosPaginados));
        }


    }
}
