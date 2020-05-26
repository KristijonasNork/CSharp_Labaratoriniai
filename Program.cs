using System;
using System.Collections.Generic;

namespace Labaratoriniai_csharp
{
    class Studentas{
        string vardas, pavarde;
        int[] ndRez;
        int egzRez;

        Studentas(string vardas, string pavarde, int[] ndRez, int egzRez)
        {
            this.vardas = vardas;
            this.pavarde = pavarde;
            this.ndRez = ndRez;
            this.egzRez = egzRez;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Studentas> studentai = new List<Studentas>();
            while (true)
            {
                Console.WriteLine("1.irasyti studentus ");
                Console.WriteLine("2.iseiti ");
                var meniu = Console.ReadLine();
                if (meniu.Equals("1")) {

                    Console.WriteLine("parasykite studento varda: ");
                    Console.ReadLine();

                }
                if (meniu.Equals("2"))
                {
                    break;
                }

            }

        }
    }
}
