using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Web_App1.Models;

namespace Web_App1.Controllers
{
    public class EmpleadoController : Controller
    {
        public readonly IConfiguration _configuration;
        public EmpleadoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        IEnumerable<Distritos> listaDistritos()
        {
            List<Distritos> lista = new List<Distritos>();
            using (SqlConnection cn = new(_configuration["ConnectionStrings:DBcx"]))
            {
                SqlCommand cmd = new SqlCommand("usp_listarDistrito", cn);
                cn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lista.Add(new Distritos
                    {
                        idDistrito = r.GetInt32(0),
                        nomDistrito = r.GetString(1)
                    });
                }
            }
            return lista;
        }



        IEnumerable<Empleados> listaEmpleadoDistrito(int idDistrito)
        {
            List<Empleados> lista = new List<Empleados>();
            using (SqlConnection cn = new(_configuration["ConnectionStrings:DBcx"]))
            {
                SqlCommand cmd = new SqlCommand("usp_EmpleadosDistrito", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDistrito", idDistrito);
                cn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lista.Add(new Empleados
                    {
                        IdEmpleado = r.GetInt32(0),
                        ApeEmpleado = r.GetString(1),
                        NomEmpleado = r.GetString(2),
                        FecNac = r.GetDateTime(3),
                        DirEmpleado = r.GetString(4),
                        nomDistrito = r.GetString(5),
                        fonoEmpleado = r.GetString(6),
                        desCargo = r.GetString(7),
                        fecContrata = r.GetDateTime(8)
                    });
                }
                cn.Close();
            }
            return lista;
        }

        public async Task<IActionResult> IndexEmpleadosDistrito(int idDistrito)
        {
            ViewBag.IdDistrito = idDistrito;
            ViewBag.Distrito = new SelectList(listaDistritos(), "idDistrito", "nomDistrito");
            return View(await Task.Run(() => listaEmpleadoDistrito(idDistrito)));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}