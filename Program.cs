using System;


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
            Console.WriteLine("Hello World!");


            Console.ReadLine();
        }
    }
}
