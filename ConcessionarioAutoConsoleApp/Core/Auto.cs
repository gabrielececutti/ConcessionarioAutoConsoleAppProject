using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Core;

internal class Auto
{

    internal Marca Marca { get; }
    internal string Modello { get; }
    string Colore { get; }
    internal Motorizzazione Motorizzazione { get; init; }
    internal List<String> Optionals { get; }
    internal IServizioPersistenzaAuto ServizioPersistenzaAuto { get; }

    internal Auto(Marca marca, string modello, string colore, Motorizzazione motorizzazione, List<string> optionals, IServizioPersistenzaAuto servizioPersistenzaAuto )
    {
        Marca = marca;
        Modello = modello;
        Colore = colore;
        Motorizzazione = motorizzazione;
        Optionals = optionals;
        ServizioPersistenzaAuto = servizioPersistenzaAuto;
    }

    // da usare per le auto comprate dall user che non interagiscono con il database
    internal Auto(Marca marca, string modello, string colore, Motorizzazione motorizzazione, List<string> optionals) { 
        Marca = marca;
        Modello = modello;
        Colore = colore;
        Motorizzazione = motorizzazione;
        Optionals = optionals;
    }


    
    /// <summary>
    /// Calcola il preventivo dell'auto.
    /// </summary>
    /// <returns> <c>decimal</c> preventivo</returns>
    internal decimal CalcolaPreventivo ()
    {
        return CalcolatorePreventivo.Calcola(this);
    }

    /// <summary>
    /// Salva l'auto nel database.
    /// </summary>
    internal void Salva()
    {
        ServizioPersistenzaAuto.Save(this);
    }

    public override string ToString () 
    {
        Func<List<string>, string> OptionalsToString = optionals =>
        {
            string output = "";
            foreach (string optional in Optionals)
            {
                output += optional + ", ";
            }
            return output.Substring(0, output.Length - 2);
        };
        return $"marca: {Marca}, modello: {Modello}, colore: {Colore}, motorizzazione: {Motorizzazione}, optional: {OptionalsToString(Optionals)}";
    }

}



