using ConcessionarioAutoConsoleApp.Infrastruttura;
using ConcessionarioAutoConsoleApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;

namespace ConcessionarioAutoConsoleApp.Configurazione;
    
    public class Principale
    {
    internal static RandomAutoFactory randomAutoFactory;
    internal static UserFactory userFactory;
    internal static VerificatoreCredenziali verificatoreCredenziali;


    // aggiungere nel servizio di persitenza la scrittura su un file di testo
        public static void Main(string[] args)
        {

        // inizializzazione factory e configurazione Verificatore credenziali
        Configuratore configuratore = new Configuratore(new AutoDB(), new UsersDB());

        // assegnamento riferimento alle factory
        randomAutoFactory = configuratore.RandomAutoFactory;
        userFactory = configuratore.UserFactory;

        // assegnamento e riferimento al Verifictore credenziali
        verificatoreCredenziali = configuratore.VerificatoreCredenziali;

        // popolo il database AutoDB (sono le auto presenti nel salone)
        int i = 0;
        while (i <=100)
        {
            randomAutoFactory.Create();
            i++;
        }

        User user;   // user per le chiamate ai metodi, verrà riaseggnato ad ogni nuovo ciclo di applicazione
        Application: while (true) {

            while (true) {
                Console.WriteLine("Premi A per accedere, premi N per creare un nuovo account.");
                string risposta = Console.ReadLine();
                if (risposta.Equals("A"))
                {
                    user = AreaAccessoAccount.Accedi();
                    break;
                } else if (risposta.Equals("N"))
                {
                    user = AreaAccessoAccount.CreaNuovoAccount();
                    break;
                }
                else
                {
                    Console.WriteLine("Tasto sbagliato. Riprova...");
                }

            }

            while (true)
            {
                Console.WriteLine("Premi V per comprare un nuova auto, P per vedere tutte le auto disponibili nel salone, A per vedere il riepilogo dell'account.");
                string risposta = Console.ReadLine();
                switch (risposta)
                {
                    case "V":
                        Auto autoNuova = user.AcquistaNuovaAuto();
                        Console.WriteLine($"Il preventivo è di {autoNuova.CalcolaPreventivo()} euro.");
                        break;
                    case "P":
                        AutoDB databaseAuto = randomAutoFactory.GetDatabaseAuto();
                        Console.WriteLine(databaseAuto.ToString());
                        break;
                    case "A":
                        Console.WriteLine(user.ToString());   
                        break;
                    default:
                        Console.WriteLine("tasto errato. Riprova");
                        continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Premi C per continure, E per uscire.");
                string risposta = Console.ReadLine();
                switch (risposta)
                {
                    case "E":
                        break;
                    case "C":
                        goto Application;
                    default:
                        Console.WriteLine("Tasto errato. Riprova...");
                        continue;
                }
                break;

            }

            break; // break application

        } 

        // osservo se i dati sono stati memorizzati correttamente 
        Console.WriteLine("Riepilogo database users: ");
        UsersDB databaseUsers = userFactory.GetDatabaseUsers();
        Console.WriteLine(databaseUsers.ToString());

    }

}

