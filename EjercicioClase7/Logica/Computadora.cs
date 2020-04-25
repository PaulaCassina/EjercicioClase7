using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Computadora:ElementoComputacion
    {
        public string DescripcionProcesador { get; set; }
        public MemoriaRAM MemoriaRAM { get; set; }
        public string NombreFabricante { get; set; }

        public void CargarDatos(string modelo, string marca, int numero, string descripcion, MemoriaRAM memoria, string fabricante)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.NumeroSerie = numero;
            this.DescripcionProcesador = descripcion;
            this.MemoriaRAM = memoria;
            this.NombreFabricante = fabricante;
        }

        public override string ObtenerDescripcion()
        {
            return $"PC{this.Modelo}- {this.Marca}- {this.DescripcionProcesador}- {this.MemoriaRAM} RAM - {this.NombreFabricante}";
        }
    }
}
