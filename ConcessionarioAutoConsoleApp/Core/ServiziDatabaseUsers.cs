using ConcessionarioAutoConsoleApp.Infrastruttura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Core
{
    /// <summary>
    /// (ADAPTER)
    /// Implementa l'interfaccia IServizioPersistenzaUser fornendo i servizi del database users.
    /// </summary>
    internal class ServiziDatabaseUsers : IServizioPersistenzaUser
    {
        internal UsersDB DatabaseUsers { get; }

        internal ServiziDatabaseUsers (UsersDB databaseUsers)
        {
            DatabaseUsers = databaseUsers;
        }

        public void Save(User user)
        {
            DatabaseUsers.saveOnDB(user);
            
        }

        public UsersDB GetUsersDB()
        {
            return DatabaseUsers;
        }
    }
}
