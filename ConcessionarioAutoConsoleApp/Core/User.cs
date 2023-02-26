using ConcessionarioAutoConsoleApp.Configurazione;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionarioAutoConsoleApp.Core;

    internal class User
    {

    internal string UserID { get; }
    internal string Password { get; }
    internal List<Auto> AutoAcquistate { get; }
    internal IServizioPersistenzaUser ServizioPersistenzaUser { get; }

    internal User (string userID, string passwordApp, List<Auto> autoAcquistate, IServizioPersistenzaUser servizioPersistenzaUser)
    {
        UserID = userID;
        Password = passwordApp;
        AutoAcquistate = autoAcquistate;
        ServizioPersistenzaUser = servizioPersistenzaUser;
    }

    /// <summary>
    /// Chiede all'utente le informazioni per l'acquisto di una nuova auto che verrà istanziata.
    /// </summary>
    /// <returns>l'auto acquistata</returns>
    internal Auto AcquistaNuovaAuto()
    {
        Auto autoNuova = AutoFactoryFromUser.Create();
        AutoAcquistate.Add(autoNuova);
        return autoNuova;
    }

    /// <summary>
    /// Salva l'user nel database.
    /// </summary>
    internal void Salva ()
    {
        ServizioPersistenzaUser.Save(this);
    }

    public override string ToString ()
    {
        Func<List<Auto>, string> AutoAcquistateToString = (autoAcquistate) =>
        {
            if (autoAcquistate.Count > 0)
            {
                string output = "";
                autoAcquistate.ForEach(auto => output += (auto.ToString() + "|"));
                return output.Substring(0, output.Length - 1);
            } else
            {
                return "nessuna.";
            }
        };

        return "UserID: " + UserID + ", password: " + Password + ", auto acquistate: " + AutoAcquistateToString(AutoAcquistate );
    }

}

