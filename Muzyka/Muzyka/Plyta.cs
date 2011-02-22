using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muzyka
{
    [Serializable]
    class Plyta
    {
        public enum TypPlyty 
        {
            CD, DVD
        }

        public string Tytul { get; set; }

        public TypPlyty Typ { get; set; }

        public List<Utwor> ListaUtworow  { get; set; } 

        public int NumerPlyty { get; set; }

        public Plyta()
        {
            ListaUtworow = new List<Utwor>();
        }

        public void WyswietlSzczegoloweInformacje()
        {
            Console.Write("---Plyta---\nTytul: {0}\nTyp plyty: {1}\nUtwory:\n {2}", Tytul, Typ, zwrocSpisUtworow());
        }

        private string zwrocSpisUtworow()
        {
            string spis = "";

            foreach (Utwor u in ListaUtworow)
                spis += "\t" + u.Numer + ". " + u.Tytul + "\n";

            return spis;
        }

        public void DodajUtwor(Utwor utwor)
        {
            ListaUtworow.Add(utwor);
        }

        public void WyswietlWykonawcow()
        {
            var wykonawcy = (from u in ListaUtworow from w in u.ListaWykonawcow select w.ToString()).Distinct();

            foreach(var w in wykonawcy)
            {
                Console.WriteLine(w.ToString());
            }
        }
    }
       
}
