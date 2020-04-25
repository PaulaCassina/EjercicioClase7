using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;

namespace EjercicioClase7
{
    class Program
    {
        static void Main(string[] args)
        {
            DepositoComputacion.Instance.ProductoAgregado_Eliminado +=Deposito_ProductoAgregado_Eliminado;
            DepositoComputacion.Instance.ProductoAgregado_Eliminado += Deposito_DescripcionPorductos;

            string modelo = Console.ReadLine();
            string marca = Console.ReadLine();
            int numeroserie = int.Parse(Console.ReadLine());
            string productoagregar = Console.ReadLine();
            if (productoagregar=="Monitor")
            {
                short anofabricacion = short.Parse(Console.ReadLine());
                Nullable<int> pulgadas = int.Parse(Console.ReadLine());
                DepositoComputacion.Instance.AgregarProducto(modelo, marca, numeroserie, anofabricacion, pulgadas);
                DepositoComputacion.Instance.AgregarProducto(modelo, marca, numeroserie, anofabricacion, 18);
                DepositoComputacion.Instance.AgregarProducto(modelo, marca, numeroserie, anofabricacion, 20);

            }
            else
            {
                string procesador = Console.ReadLine();
                string valormemoria = Console.ReadLine();
                if (valormemoria.ValidarValorMemoriaRAM())
                {
                    MemoriaRAM memoria = (MemoriaRAM)Enum.Parse(typeof(MemoriaRAM), valormemoria);
                    string fabricante = Console.ReadLine();
                    DepositoComputacion.Instance.AgregarProducto(modelo, marca, numeroserie, procesador, memoria, fabricante);
                }
                else
                {
                    throw new Exception("Valor de memoria fuera del rango");
                }        
                
            }
            Console.ReadKey();

        }

        private static void Deposito_ProductoAgregado_Eliminado(object sender, InfoProductoArgs e)
        {
            Console.WriteLine($"{e.Operacion}: {e.Tipo} -{ e.Identificador}");
        }

        private static void Deposito_DescripcionPorductos(object sender, InfoProductoArgs e)
        {
            foreach (ElementoComputacion elemento in DepositoComputacion.Instance.ObtenerListaElementosComputacion())
            {
                if (DepositoComputacion.Instance.ObtenerListaElementosComputacion().Last()==elemento)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                Console.WriteLine(DepositoComputacion.Instance.ObtenerDescripcionElementos(elemento));

            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
