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
    /// Memorizza tutte le istanze della classe <c>Auto</c> in una <c>List</c> di <c>Auto</c>.
    /// </summary>
    internal class AutoDB 
    {
        internal List<Auto> Automobili { get; }

        internal AutoDB ()
        {
            Automobili= new List<Auto> ();
        }

        internal void SaveOnDB(Auto auto)
        {
            Automobili.Add (auto);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Auto auto in Automobili)
            {
                output += auto.ToString() + "\n";
            }
            return output;

        }
    }
}