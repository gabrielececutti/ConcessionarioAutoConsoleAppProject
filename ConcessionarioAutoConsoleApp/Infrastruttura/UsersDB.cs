using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionarioAutoConsoleApp.Core;

namespace ConcessionarioAutoConsoleApp.Infrastruttura
{
    /// <summary>
    /// (ADAPTEE)
    /// Memorizza tutte le istanze della classe <c>User</c> in una <c>List</c> di <c>User</c>.
    /// </summary>
    internal class UsersDB
    {
        internal List<User> users;

        internal UsersDB() { 
            users = new List<User>();
        }

        internal void saveOnDB (User user)
        {
            users.Add(user);
        }

        internal List<User> GetUsers()
        {
            return this.users;
        }

        public override string ToString ()
        {
            string output = "";
            foreach (User user in users)
            {
                output += user.ToString() + "\n";
            }
            return output;
        }
    }
}
