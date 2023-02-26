using ConcessionarioAutoConsoleApp.Infrastruttura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Core
{
    /// <summary>
    /// (TARGET)
    /// Fornisce tutti i servizi di persistenza della classe <c>User</c>.
    /// </summary>
    internal interface IServizioPersistenzaUser
    {
        /// <summary>
        /// Salva l'user nel database.
        /// </summary>
        /// <param name="user">l'user da salvare</param>
        internal void Save(User user);

        /// <summary>
        /// Ritorna il database degli users.
        /// </summary>
        /// <returns><c>UsersDB</c></returns>
        internal UsersDB GetUsersDB();
    }
}
