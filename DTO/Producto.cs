using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.DTO
{
    public class Producto
    {
        public int Id { get; set; }

        public int ProveedorId { get; set; }

        public int CategoriaId { get; set; }

        public int MarcaId { get; set; }

        public string CodigoBarras { get; set; }

        public string Descripcion { get; set; }

        public string Medidas { get; set; }

        public double Precio { get; set; }

        public double Stock { get; set; }

        public bool Activo
        {
            get; set;
        }
    }
}
