using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Configurazione
{
    internal class Prova
    {
        private readonly string [] array;

        public int numero = 1;

        public Prova(string[] array) { 
        this.array = array;
        }

        public int GetInt ()
        {
            return numero;
        }


        public string[] GetArray ()
        {
            return array;
        }


        public static void Main (String[] args)
        {
            string[] array = { "ciao", "a", "tutti" };
            Prova p = new Prova(array);

            // anche se la variabile di istanza è redonly, si può modificare tramite 
            string[] arr = p.GetArray();  // arr = p.array arr punta alla variabile di istanza
            arr[0] = "variabile modificata"; // come faccio a non modificarlo => il get ritorna una copia
            string[] a = p.GetArray ();
            Console.WriteLine(a[0]);


        }
    }
}
