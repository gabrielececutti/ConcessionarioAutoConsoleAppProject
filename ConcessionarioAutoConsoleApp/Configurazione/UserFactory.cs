using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionarioAutoConsoleApp.Core;
using ConcessionarioAutoConsoleApp.Infrastruttura;

namespace ConcessionarioAutoConsoleApp.Configurazione
{
    internal class UserFactory
    {
        internal IServizioPersistenzaUser ServizioPersistenzaUser { get; }
        internal UserFactory(UsersDB usersDB) { 
            ServizioPersistenzaUser = new ServiziDatabaseUsers(usersDB);
        }

        /// <summary>
        /// Crea un nuovo user da input utente.
        /// </summary>
        /// <returns><c>User</c></returns>
        internal User Create()
        {
            Console.WriteLine("Inserisci un nuovo userID: ");
            string userID = Console.ReadLine();
            Console.WriteLine("Inserisci una nuova password: ");
            string password = Console.ReadLine();
            return new User (userID, password, new List<Auto> (), ServizioPersistenzaUser);
        }

        internal UsersDB GetDatabaseUsers()
        {
           return ServizioPersistenzaUser.GetUsersDB();
        }

    }
}
