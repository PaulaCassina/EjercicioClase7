using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Monitor:ElementoComputacion
    {
        public short AnoFabricacion { get; set; }
        public bool  Esnuevo { get { return AnoFabricacion == DateTime.Today.Year ? true : false; } }
        public Nullable<int> Pulgadas { get; set; }

        public void CargarDatos(string modelo, string marca, int numero, short anofabricacion, Nullable<int> pulgadas)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.NumeroSerie = numero;
            this.AnoFabricacion = anofabricacion;
            this.Pulgadas = pulgadas;
        }
    }
}
 