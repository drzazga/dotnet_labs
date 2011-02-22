using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Muzyka
{
    class Program
    {
        public static List<Plyta> bazaPlyt;

        static void Main(string[] args)
        {
            bazaPlyt = new List<Plyta>();
            Plyta plyta1 = new Plyta();
            plyta1.Tytul = "Swiatla Miasta";
            plyta1.NumerPlyty = 1;
            plyta1.Typ = Plyta.TypPlyty.CD;

            Plyta plyta2 = new Plyta();
            plyta2.Tytul = "3";
            plyta2.NumerPlyty = 2;
            plyta2.Typ = Plyta.TypPlyty.CD;

            Wykonawca wykonawca = new Wykonawca();
            wykonawca.Nazwa = "Grammatik";
            wykonawca.Typ = Wykonawca.TypWykonawcy.ZESPOL;

            Wykonawca wykonawca2 = new Wykonawca();
            wykonawca2.Nazwa = "RR Brygada";
            wykonawca2.Typ = Wykonawca.TypWykonawcy.ZESPOL;

            Wykonawca wykonawca3 = new Wykonawca();
            wykonawca3.Imie = "Edyta";
            wykonawca3.Nazwisko = "Geppert";
            wykonawca3.Typ = Wykonawca.TypWykonawcy.OSOBA;

            Utwor utwor1 = new Utwor();
            utwor1.CzasTrwania = 250;
            utwor1.Kompozytor = "Eldoka";
            utwor1.Tytul = "Wiatru Cien";
            utwor1.ListaWykonawcow.Add(wykonawca);
            utwor1.ListaWykonawcow.Add(wykonawca2);
            utwor1.ListaWykonawcow.Add(wykonawca3);
            utwor1.Numer = 1;

            Utwor utwor2 = new Utwor();
            utwor2.CzasTrwania = 250;
            utwor2.Kompozytor = "Eldoka";
            utwor2.Tytul = "Puste pokoje";
            utwor2.ListaWykonawcow.Add(wykonawca);
            utwor2.ListaWykonawcow.Add(wykonawca2);
            utwor2.ListaWykonawcow.Add(wykonawca3);
            utwor2.Numer = 2;

            //utwor2.WyswietlInformacje();

            plyta1.DodajUtwor(utwor1);
            plyta1.DodajUtwor(utwor2);
            //plyta1.WyswietlSzczegoloweInformacje();

            DodajPlyteDoBazy(plyta1);

            //plyta1.WyswietlWykonawcow();
            ZapiszBazeDoPliku();
            DodajPlyteDoBazy(plyta2);     
            WyswietlTytulyPlyt();
            WczytajBazeZPliku();
            WyswietlTytulyPlyt();
            Console.ReadLine();
        }

        static void DodajPlyteDoBazy(Plyta plyta)
        {
            bazaPlyt.Add(plyta);
        }

        static void ZapiszBazeDoPliku()
        {
            Stream s = File.Open("Baza.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(s, bazaPlyt);
            s.Close();
        }

        static void WczytajBazeZPliku()
        {
            Stream s = File.Open("Baza.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            object o = bf.Deserialize(s);
            bazaPlyt = o as List<Plyta>;
        }

        static void WyswietlTytulyPlyt()
        {
            Console.Write("Tytuly plyt w bazie:");

            string tytuly = "";

            foreach(Plyta plyta in bazaPlyt)
                tytuly += "\n\t-" + plyta.Tytul;

            Console.WriteLine(tytuly);
        }
    }
}
