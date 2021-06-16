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
    public class MarcaController : Controller
    {
        private readonly Connect.Context context;

        public MarcaController(Connect.Context _context)
        {
            context = _context;
        }

        [HttpGet("buscar/listar")]
        public List<DTO.Listados> getMarcas()
        {
            List<DTO.Listados> result = new List<DTO.Listados>();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "accion", Value = "Listar" }
            };
            var list = context.Marcas.FromSqlRaw<Models.Marca>("exec Sp_Bus_Marca  @accion ", parametros.ToArray()).ToList();

            foreach (var item in list)
            {
                result.Add(new DTO.Listados { id = item.Id, nombre = item.Nombre });
            }

            return result;

             
        }
    }
}
