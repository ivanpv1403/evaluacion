using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Models
{
    public class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }
     
        public int Id { get; set; }
        public char TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Observacion { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
