using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muzyka
{
    [Serializable]
    class Wykonawca
    {
        public enum TypWykonawcy
        {
            OSOBA, ZESPOL
        }

        public string Nazwa { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public TypWykonawcy Typ;

        public override string ToString()
        {
            if(Typ.Equals(TypWykonawcy.ZESPOL))
                return Nazwa;
            else
                return Imie + " " + Nazwisko;
        }
    }
}
