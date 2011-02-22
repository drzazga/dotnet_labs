using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muzyka
{
    [Serializable]
    class Utwor
    {
        public string Tytul  { get; set; }

        public int CzasTrwania { get; set; }

        public short Numer { get; set; }

        public List<Wykonawca> ListaWykonawcow { get; set; }

        public string Kompozytor { get; set; }

        public Utwor()
        {
            ListaWykonawcow = new List<Wykonawca>();
        }

        public void WyswietlInformacje()
        {
            Console.Write("----Utwor----\nTytul: {0}\nCzas trwania(sek): {1}\nWykonawcy:{2}\nKompozytor: {3}\n", Tytul, CzasTrwania, zwrocWykonawcow(), Kompozytor);
        }

        private string zwrocWykonawcow()
        {
            string wykonawcy = "";

            foreach(Wykonawca w in ListaWykonawcow)
            {
                wykonawcy += "\n\t" + w.ToString(); 
            }

            return wykonawcy;
        }
    }
}
