using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public sealed class DepositoComputacion
    {
        public List<ElementoComputacion> ListaElementosDeComputacion { get; set; }
        private static DepositoComputacion instance = null;

        private DepositoComputacion()
        {

        }
   
        public static DepositoComputacion Instance 
        {
            get
            {
                if (instance==null)
                {
                    instance = new DepositoComputacion();
                }
                return instance;
            }
        }

        public void AgregarProducto(string modelo, string marca, int numero, short anofabricacion, Nullable<int> pulgadas)
        {
            Monitor nuevoMonitor = new Monitor();
            nuevoMonitor.CargarDatos(modelo, marca, numero, anofabricacion, pulgadas);
            ListaElementosDeComputacion.Add(nuevoMonitor);
        }
       
        public void AgregarProducto(string modelo, string marca, int numero, string descripcion, MemoriaRAM memoria, string fabricante)
        {
            Computadora nuevaComputadora = new Computadora();
            nuevaComputadora.CargarDatos(modelo, marca, numero, descripcion, memoria, fabricante);
            ListaElementosDeComputacion.Add(nuevaComputadora);
        }

        public bool EliminarProductoLista(string identificador)
        {
            ElementoComputacion elementoEncontrado = ListaElementosDeComputacion.Find(x => x.Identificador == identificador);
            if (elementoEncontrado!=null)
            {
                ListaElementosDeComputacion.Remove(elementoEncontrado);
                return true;
            }
            return false;
        }

        
    }
}
