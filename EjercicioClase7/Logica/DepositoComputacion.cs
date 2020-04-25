using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public sealed class DepositoComputacion
    {
        public List<Monitor> ListaMonitores { get; set; }
        public List<Computadora> ListaComputadoras { get; set; }
        private static DepositoComputacion instance = null;
        public EventHandler<InfoProductoArgs> ProductoAgregado_Eliminado;

        private DepositoComputacion()
        {
            ListaMonitores = new List<Monitor>();
            ListaComputadoras = new List<Computadora>();
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
            ListaMonitores.Add(nuevoMonitor);
            this.ProductoAgregado_Eliminado(this, new InfoProductoArgs()
            {
                Tipo = "Monitor",
                Identificador = nuevoMonitor.Identificador,
                Operacion="Agregar"
            
            });
            
        }

        public void AgregarProducto(string modelo, string marca, int numero, string descripcion, MemoriaRAM memoria, string fabricante)
        {
            Computadora nuevaComputadora = new Computadora();
            nuevaComputadora.CargarDatos(modelo, marca, numero, descripcion, memoria, fabricante);
            ListaComputadoras.Add(nuevaComputadora);
            this.ProductoAgregado_Eliminado(this, new InfoProductoArgs()
            {
                Tipo = "Computadora",
                Identificador = nuevaComputadora.Identificador,
                Operacion = "Agregar"
            });
        }

        public bool EliminarProductoLista(string identificador)
        {
            List<ElementoComputacion> listaElementos = ObtenerListaElementosComputacion();
            ElementoComputacion elementoEncontrado = listaElementos.Find(x => x.Identificador == identificador);
            string tipoproducto;
            if (elementoEncontrado!=null)
            {
                if (elementoEncontrado is Monitor)
                {
                    ListaMonitores.Remove(elementoEncontrado as Monitor);
                    tipoproducto = "Monitor";
                }
                else
                {
                    ListaComputadoras.Remove(elementoEncontrado as Computadora);
                    tipoproducto = "Computadora";
                }
                this.ProductoAgregado_Eliminado(this, new InfoProductoArgs()
                {
                    Tipo = tipoproducto,
                    Identificador = elementoEncontrado.Identificador,
                    Operacion = "Eliminar"

                });

                return true;
            }
            return false;
        }

        public List<ElementoComputacion>ObtenerListaElementosComputacion()
        {
            List<ElementoComputacion> listaElementosComputacion = new List<ElementoComputacion>();
            listaElementosComputacion.AddRange(ListaMonitores);
            listaElementosComputacion.AddRange(ListaComputadoras);
            return listaElementosComputacion;
        }

        public string ObtenerDescripcionElementos(ElementoComputacion elemento)
        {
            if (elemento is Monitor)
            {
               return (elemento as Monitor).ObtenerDescripcion();
            }
            return (elemento as Computadora).ObtenerDescripcion();
        }
  
    }
}
