using ConcessionarioAutoConsoleApp.Configurazione;
using ConcessionarioAutoConsoleApp.Infrastruttura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Core
{
    internal class AreaAccessoAccount
    {

        /// <summary>
        /// Chiede all'utente le credenziali di accesso. Quando saranno inseriti i dati corretti verrà ritornato l'user stesso.
        /// </summary>
        /// <returns><c>User</c></returns>
        internal static User Accedi ()
        {
            while (true)
            {
                Console.WriteLine("Inserisci userID: ");
                string userID = Console.ReadLine();
                Console.WriteLine("Inserisci password: ");
                string password = Console.ReadLine();

                VerificatoreCredenziali verificatoreCredenziali = Principale.verificatoreCredenziali;
                try
                {
                    User user = verificatoreCredenziali.Verifica(userID, password);
                    return user;
                }
                catch (AccessoNegatoException)
                {
                    Console.WriteLine("Account non esistente oppure credenziali errate. Riprova...");
                }
            }
        }

        /// <summary>
        /// Crea un nuovo account e lo ritorna.
        /// </summary>
        /// <returns><c>User</c></returns>
        internal static User CreaNuovoAccount ()
        {
            UserFactory userFactory = Principale.userFactory;
            User user = userFactory.Create();
            user.Salva();
            return user; 
        }

    }
}
