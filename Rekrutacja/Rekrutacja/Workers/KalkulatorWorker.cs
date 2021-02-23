using Soneta.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soneta.Kadry;
using Soneta.KadryPlace;
using Soneta.Types;
using Soneta.Business.UI;
using Rekrutacja.Workers;

[assembly: Worker(typeof(KalkulatorWorker), typeof(Pracownicy))]
namespace Rekrutacja.Workers
{
    class KalkulatorWorker
    {
        [Context]
        public Context Context { get; set; }

        [Context]
        public KalkulatorParams Parametry { get; set; }

        [Action("Kalkulator",
           Description = "Prosty kalkulator ",
           Priority = 10,
           Mode = ActionMode.ReadOnlySession,
           Icon = ActionIcon.Accept,
           Target = ActionTarget.ToolbarWithText)]
        public void WykonajAkcje()
        {
            DebuggerSession.MarkLineAsBreakPoint();

            if (!ContextZawieraPracownikow()) return;

            Pracownik[] pracownicy = PobierzPracownikowZContextu();

            using (Session nowaSesja = this.Context.Login.CreateSession(false, false, "ModyfikacjaPracownika"))
            {
                using (ITransaction transakcja = nowaSesja.Logout(true))
                {
                    ZapiszDanePracownikow(nowaSesja, pracownicy);
                    transakcja.CommitUI();
                }
                nowaSesja.Save();
            }
        }

        private void ZapiszDanePracownikow(Session sesja, Pracownik[] pracownicy)
        {
            double wynik = Kalkulator.Oblicz((double)this.Parametry.A, (double)this.Parametry.B, this.Parametry.Operacja);
            foreach (Pracownik pracownik in pracownicy)
            {
                var pracownikZSesja = sesja.Get(pracownik);
                pracownikZSesja.Features["DataObliczen"] = this.Parametry.DataObliczen;
                pracownikZSesja.Features["Wynik"] = wynik;
            }
        }


        private Pracownik[] PobierzPracownikowZContextu()
        {
            return (Pracownik[])(this.Context[typeof(Pracownik[])]);
        }

        private bool ContextZawieraPracownikow()
        {
            return Context.Contains(typeof(Pracownik[]));
        }
    }
}
