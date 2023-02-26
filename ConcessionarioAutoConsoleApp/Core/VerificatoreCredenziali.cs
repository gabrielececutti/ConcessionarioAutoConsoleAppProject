using ConcessionarioAutoConsoleApp.Infrastruttura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Core
{
    internal class VerificatoreCredenziali
    {

        internal UsersDB DatabaseUsers { get; }

        internal VerificatoreCredenziali(UsersDB usersDB)
        {
            DatabaseUsers = usersDB;
        }

        /// <summary>
        /// Verifica che le credenziali inseirte siano giuste.
        /// </summary>
        /// <param name="userIDDigitato">L'user digitato dall'utente.</param>
        /// <param name="passwordDigitata">La password digitata dall'utente.</param>
        /// <returns>L'user </returns>
        /// <exception cref="AccessoNegatoException"> Se le credenziali sono errate o l'user non è esistente.</exception>
        internal User Verifica(string userIDDigitato, string passwordDigitata)
        {
            foreach (var user in DatabaseUsers.GetUsers())
            {
                if (user.UserID.Equals(userIDDigitato) && user.Password.Equals(passwordDigitata))
                {
                    return user;
                }
            }
            throw new AccessoNegatoException();
        }
    }
}

