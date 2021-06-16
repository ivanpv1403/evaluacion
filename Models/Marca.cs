﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Models
{
    public class Marca
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public bool Activo { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
