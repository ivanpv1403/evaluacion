using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Evaluacion.Models
{
    public class Producto
    {
        public Producto()
        {
            Historicos = new HashSet<Historico>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public int ProveedorId { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        [Required]
        public int MarcaId { get; set; }
        [Required]
        public string CodigoBarras { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Medidas { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public double Stock { get; set; }
        [Required]
        public bool Activo { get; set; }

        public Proveedor Proveedor { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }

        public ICollection<Historico> Historicos { get; set; }
    }
}
