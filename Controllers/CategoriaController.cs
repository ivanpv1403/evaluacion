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
    public class CategoriaController : Controller
    {
        private readonly Connect.Context context;

        public CategoriaController(Connect.Context _context)
        {
            context = _context;
        }

        [HttpGet("buscar/listar")]
        public List<DTO.Listados> getCategorias()
        {
            List<DTO.Listados> result = new List<DTO.Listados>();
            List<SqlParameter> parametros = new List<SqlParameter>
            {   
                new SqlParameter { ParameterName = "accion", Value = "Listar" }
            };
            var listCategoria = context.Categorias.FromSqlRaw<Models.Categoria>("exec Sp_Bus_Categoria  @accion ", parametros.ToArray()).ToList();

            foreach (var item in listCategoria)
            {
                result.Add(new DTO.Listados { id = item.Id, nombre = item.Nombre });
            }

            return result;

            /* = (from c in context.Categorias
                           where c.Nombre.Contains(filtro)
                           select c).ToList();
            */           
        }

    }
}
