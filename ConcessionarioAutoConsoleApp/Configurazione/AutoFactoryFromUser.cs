using ConcessionarioAutoConsoleApp.Core;
using ConcessionarioAutoConsoleApp.Infrastruttura;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Configurazione
{
    internal class AutoFactoryFromUser
    {

        /// <summary>
        /// Crea un auto da input utente.
        /// </summary>
        /// <returns><c>Auto</c></returns>
        internal static Auto Create()
        {
            while (true)
            {
                Console.WriteLine("Seleziona una marca: ");
                string marcaString = Console.ReadLine(); // da trasformare in un enum
                bool conversione1 = Enum.TryParse(marcaString, true, out Marca resultMarca);
                Console.WriteLine("Scrivi il modello: ");
                string modello = Console.ReadLine();
                Console.WriteLine("Scegli il colore: ");
                string colore = Console.ReadLine();
                Console.WriteLine("Seleziona il tipo di motorizzazione: ");
                string motorizzazione = Console.ReadLine(); // da trasformare in un enum
                bool conversione2 = Enum.TryParse(motorizzazione, true, out Motorizzazione resultMotorizzazione);

                // verifico se la conversioni da string ad enum hanno avuto esito postivo
                if (conversione1 && conversione2)
                {
                    // la conversione ha avuto esito positivo
                }else
                {
                    Console.WriteLine("Marca e/o motorizzazione non esistente. Riprova...");
                    continue;
                }
      
                Console.WriteLine("Inserisci gli optionals (separatore = \", \"): ");
                string optionals = Console.ReadLine(); 
                string[] arrayOfOptionals = optionals.Split(", "); // ATTENZIONE se il separatore non viene rispettato, crea un array di un solo elemento
                List<string> listOfOptionals = arrayOfOptionals.ToList();
                Auto auto = new Auto(resultMarca, modello, colore, resultMotorizzazione, listOfOptionals);
                return auto;
            }
            
        }
    }

       
}
