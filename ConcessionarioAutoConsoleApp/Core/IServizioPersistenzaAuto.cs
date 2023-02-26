using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionarioAutoConsoleApp.Infrastruttura;

namespace ConcessionarioAutoConsoleApp.Core
{
    /// <summary>
    /// (TARGET)
    /// Fornisce tutti i servizi di persistenza della classe <c>Auto</c>.
    /// </summary>
    internal interface IServizioPersistenzaAuto
    {
        /// <summary>
        /// Salva l'auto nel database.
        /// </summary>
        /// <param name="auto">l'auto da salvare</param>
        internal void Save (Auto auto);

        /// <summary>
        /// Ritorna il database dove vengono salvate le auto.
        /// </summary>
        /// <returns><c>AutoDB</c></returns>
        internal AutoDB GetAutoDB();

        // internal void SaveOnTextFile ()
        // devo creareun nuova classe che implementa questo metodo e che ha un costruttore in cui 
        //viene passato il databse 
       
    }
}
