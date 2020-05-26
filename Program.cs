using System;
using System.Collections.Generic;

namespace Labaratoriniai_csharp
{
    class Studentas{
        string vardas, pavarde;
        double[] ndRez;
        double egzRez;

        Studentas(string vardas, string pavarde, double[] ndRez, double egzRez)
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
                    var vardas = Console.ReadLine();
                    Console.WriteLine("parasykite studento pavarde: ");
                    var pavarde = Console.ReadLine();
                    Console.WriteLine("parasykite studento balus, kai baigsite parasykite -1: ");
                    double balas = 0;
                    List<double> balai = new List<double>();
                    while (balas != -1)
                    {
                        balas = Convert.ToDouble(Console.ReadLine());
                        if (balas != -1)
                        {
                            balai.Add(balas);
                        }
                    }
                    double[] ndRez = new double[balai.Count];
                    int i = 0;
                    foreach(double bal in balai)
                    {
                        ndRez[i] = bal;
                        i++;
                    }

                    Console.WriteLine("parasykite studento pavarde: ");
                    double egzRez = Console.ReadLine();

                }
                if (meniu.Equals("2"))
                {
                    break;
                }

            }

        }
    }
}
