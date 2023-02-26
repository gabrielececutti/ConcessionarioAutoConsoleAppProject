using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Core
{
    internal static class CalcolatorePreventivo
    {

        /// <summary>
        /// Calcola il costo base dell'auto in base alla sua marca.
        /// </summary>
        /// <param name="marca">La marca dell'auto</param>
        /// <returns><c>deciaml</c> prezzo</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static decimal CostoAutoBase(Marca marca) => marca switch
        {
            Marca.AUDI => 20000,
            Marca.BMW => 30000,
            Marca.ALFA_ROMEO => 20000,
            Marca.VOLKSWAGEN => 10000,
            Marca.TOYOTA => 10000,
            Marca.SEAT => 8000,
            Marca.FIAT => 7000,
            Marca.DACIA => 6000,
            Marca.HONDA => 9000,
            Marca.MERCEDES => 20000,
            _ => throw new NotImplementedException()
        };

        /// <summary>
        /// Calcola il costo totale degli optionals.
        /// </summary>
        /// <param name="optionals">La lista contenente gli optonals</param>
        /// <returns> <c>decimal</c> prezzo</returns>
        private static decimal CostoOptionals (List<string> optionals)
        {
            int i = optionals.Count;
            return i * 500;
        }

        /// <summary>
        /// Calcola il preventivo dell'auto.
        /// </summary>
        /// <param name="auto"></param>
        /// <returns> <c>decimal</c> preventivo</returns>
        internal static decimal Calcola (Auto auto)
        {
            return CostoAutoBase(auto.Marca) + CostoOptionals(auto.Optionals);
        }
    }
}
