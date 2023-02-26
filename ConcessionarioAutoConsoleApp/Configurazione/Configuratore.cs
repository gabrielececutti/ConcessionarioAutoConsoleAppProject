using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionarioAutoConsoleApp.Core;
using ConcessionarioAutoConsoleApp.Infrastruttura;

namespace ConcessionarioAutoConsoleApp.Configurazione
{
    /// <summary>
    /// Inizializza le factory e il verificatore delle credenziali.
    /// </summary>
    internal class Configuratore
    {
        internal RandomAutoFactory RandomAutoFactory { get; }
        internal UserFactory UserFactory { get; }
        internal VerificatoreCredenziali VerificatoreCredenziali { get; }

        internal Configuratore ( AutoDB autoDB, UsersDB usersDB)
        {
            RandomAutoFactory = new RandomAutoFactory(autoDB);
            UserFactory = new UserFactory(usersDB);
            VerificatoreCredenziali = new VerificatoreCredenziali(usersDB);
        }

        //internal RandomAutoFactory GetRandomAutoFactory()
        //{
        //    return RandomAutoFactory;
        //}

        //internal UserFactory GetUserFactory()
        //{
        //    return UserFactory;
        //}

        //internal VerificatoreCredenziali GetVerificatoreCredenziali ()
        //{
        //    return VerificatoreCredenziali;
        //}
    }
}
