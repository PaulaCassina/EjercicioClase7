using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public enum MemoriaRAM
    {
        Dos,
        Cuatro,
        Ocho,
        Dieciseis
    }

    public static class Extensiones
    {
        public static bool ValidarValorMemoriaRAM(this string valor)
        {
            return Enum.IsDefined(typeof(MemoriaRAM), valor);
        }
    }
}
