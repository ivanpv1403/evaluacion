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
    public class ProductoController : Controller
    {
        private readonly Connect.Context context;

        public ProductoController(Connect.Context _context)
        {
            context = _context;
        }

        [HttpGet("buscar/id/{id}")]
        public DTO.Producto getById(int id)
        {
             
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@accion", Value = "id" },
                new SqlParameter { ParameterName = "@id", Value = id }
            };
            var item = context.Productos.FromSqlRaw<Models.Producto>("exec Sp_Bus_Producto  @accion, @id ", parametros.ToArray()).ToList();

            if (item != null)
                if (item.Count > 0)
                    return (new DTO.Producto
                    {
                        Id = item[0].Id,
                        ProveedorId = item[0].ProveedorId,
                        CategoriaId = item[0].CategoriaId,
                        MarcaId = item[0].MarcaId,
                        CodigoBarras = item[0].CodigoBarras,
                        Descripcion = item[0].Descripcion,
                        Medidas = item[0].Medidas,
                        Precio = item[0].Precio,
                        Stock = item[0].Stock,
                        Activo = item[0].Activo
                    });
                else
                    return new DTO.Producto();
            else
                return new DTO.Producto();
            
 
        }

        [HttpGet("buscar/descripcion/{filtro}")]
        public List<DTO.Producto> getByDescripcion(string filtro)
        {
            List<DTO.Producto> result = new List<DTO.Producto>();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@accion", Value = "descripcion" },
                new SqlParameter { ParameterName = "@id", Value = 0 },
                new SqlParameter { ParameterName = "@descripcion", Value = filtro }
            };
            var items = context.Productos.FromSqlRaw<Models.Producto>("exec Sp_Bus_Producto  @accion,@id, @descripcion ", parametros.ToArray()).ToList();

            foreach (var item in items)
            {
                result.Add(new DTO.Producto
                {
                    Id = item.Id,
                    ProveedorId = item.ProveedorId,
                    CategoriaId = item.CategoriaId,
                    MarcaId = item.MarcaId,
                    CodigoBarras = item.CodigoBarras,
                    Descripcion = item.Descripcion,
                    Medidas = item.Medidas,
                    Precio = item.Precio,
                    Stock = item.Stock,
                    Activo = item.Activo
                });
            }

            return result;

        }

        [HttpPost("guardar")]
        public async Task<ActionResult<DTO.Producto>> CreateProducto([FromBody] DTO.Producto item)
        {
            Models.Producto objProducto = new Models.Producto
            {
                ProveedorId = item.ProveedorId,
                CategoriaId = item.CategoriaId,
                MarcaId = item.MarcaId,
                CodigoBarras = item.CodigoBarras,
                Descripcion = item.Descripcion,
                Medidas = item.Medidas,
                Precio = item.Precio,
                Stock = item.Stock,
                Activo = true
            };
            context.Productos.Add(objProducto);
            await context.SaveChangesAsync();
            item.Id = objProducto.Id;
            return item;
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult<DTO.Producto>> UpdateProducto([FromBody] DTO.Producto item)
        {
            Models.Producto objProducto = new Models.Producto
            {
                Id = item.Id,
                ProveedorId = item.ProveedorId,
                CategoriaId = item.CategoriaId,
                MarcaId = item.MarcaId,
                CodigoBarras = item.CodigoBarras,
                Descripcion = item.Descripcion,
                Medidas = item.Medidas,
                Precio = item.Precio,
                Stock = item.Stock,
                Activo = item.Activo
            };
            context.Entry(objProducto).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return item;
        }

    }
}
