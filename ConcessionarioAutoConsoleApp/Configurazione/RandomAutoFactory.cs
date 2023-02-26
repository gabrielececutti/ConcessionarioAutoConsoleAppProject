using ConcessionarioAutoConsoleApp.Core;
using ConcessionarioAutoConsoleApp.Infrastruttura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Configurazione
{

    internal class RandomAutoFactory 
    {

        internal IServizioPersistenzaAuto ServizioPersistenzaAuto { get; }

        internal RandomAutoFactory(AutoDB autoDB)
        {
            ServizioPersistenzaAuto = new ServiziDatabaseAuto(autoDB);
        }


        /// <summary>
        /// Ritorna una lista di 5 auto generiche.
        /// </summary>
        /// <returns><c>List<Auto></c></returns>
        private List<Auto> GenericsAuto ()
        {
            string[] optionals1 = { "freni maggiorati", "scarico sportivo", "pacchetto mappe" };
            string[] optionals2 = { "cerchi premium", "sedili riscaldati", };
            string[] optionals3 = { "cambio sequenziale", "finestrini oscurati" };
            string[] optionals4 = { "scarico sportivo" };
            string[] optionals5 = { "sedili riscaldati", "cruise control" };

            Auto auto1 = new Auto(Marca.AUDI,"Q5", "bianco", Motorizzazione.DIESEL, optionals5.ToList(), ServizioPersistenzaAuto );
            Auto auto2 = new Auto(Marca.BMW, "M4", "nero", Motorizzazione.BENZINA, optionals1.ToList(), ServizioPersistenzaAuto);
            Auto auto3 = new Auto(Marca.ALFA_ROMEO, "stelvio", "rosso", Motorizzazione.DIESEL, optionals3.ToList(), ServizioPersistenzaAuto);
            Auto auto4 = new Auto(Marca.VOLKSWAGEN, "golfGT", "grigio", Motorizzazione.BENZINA, optionals4.ToList(), ServizioPersistenzaAuto);
            Auto auto5 = new Auto(Marca.FIAT, "500L", "verde", Motorizzazione.IBRIDA, optionals2.ToList(), ServizioPersistenzaAuto);

            List<Auto> genericheAuto = new List<Auto>();
            genericheAuto.Add(auto1);
            genericheAuto.Add(auto2);
            genericheAuto.Add(auto3);
            genericheAuto.Add(auto4);
            genericheAuto.Add(auto5);
            return genericheAuto;
        }

        /// <summary>
        /// Crea un auto generica.
        /// </summary>
        /// <returns></returns>
        internal Auto Create ()
        {
            List<Auto> genericheAuto = GenericsAuto();
            Random random= new Random();
            int i = (int) random.NextInt64(0, genericheAuto.Count);
            Auto auto = genericheAuto[i];
            auto.Salva();
            return auto;
        }

        internal AutoDB GetDatabaseAuto ()
        {
            return ServizioPersistenzaAuto.GetAutoDB();
        }

    }
}
