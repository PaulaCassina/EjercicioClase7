using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ElementoComputacion
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int NumeroSerie { get; set; }
        public string  Identificador { get { return $"{this.Modelo}-{this.Marca}-{(this.NumeroSerie).ToString()}"; } }
    }
}
