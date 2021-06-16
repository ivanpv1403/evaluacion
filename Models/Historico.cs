using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Models
{
    public class Historico
    {
        public Historico()
        {
           
        }
        public int Id { get; set; }
        public int ProductoId { get; set; }       
        public string Accion { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }

        public DateTime fecha { get; set; }

        public Producto Producto { get; set; }
    }
}
