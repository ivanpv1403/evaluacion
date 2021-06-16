using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace Evaluacion.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProveedorController : Controller
    {
        private readonly Connect.Context context;

        public ProveedorController(Connect.Context _context)
        {
            context = _context;
        }

        [HttpGet("buscar/listar")]
        public List<DTO.Listados> getProveedores()
        {
            List<DTO.Listados> result = new List<DTO.Listados>();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "accion", Value = "Listar" }
            };
            var list  = context.Proveedores.FromSqlRaw<Models.Proveedor>("exec Sp_Bus_Proveedor  @accion ", parametros.ToArray()).ToList();

            foreach (var item in list)
            {
                result.Add(new DTO.Listados { id = item.Id, nombre = item.Nombre });
            }

            return result;
        }
    }
}
