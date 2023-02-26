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
    /// Implementa l'interfaccia IServizioPersistenzaAuto fornendo i servizi del database auto.
    /// </summary>
    internal class ServiziDatabaseAuto : IServizioPersistenzaAuto
    {

        internal AutoDB DatabaseAutomobili { get; }

        internal ServiziDatabaseAuto (AutoDB databaseAutomobili)
        {
            DatabaseAutomobili = databaseAutomobili;
        }

        public void Save(Auto auto)
        {
           DatabaseAutomobili.SaveOnDB(auto);
        }

        public AutoDB GetAutoDB()
        {
            return DatabaseAutomobili;
        }


    }
}
