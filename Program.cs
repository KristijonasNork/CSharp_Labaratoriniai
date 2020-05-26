using System;
using System.Collections.Generic;

namespace Labaratoriniai_csharp
{
    public class Studentas{
        public string vardas, pavarde;
        public double[] ndRez;
        public double egzRez;

        public Studentas(string vardas, string pavarde, double[] ndRez, double egzRez)
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
            studentai.Add(new Studentas("Tomas", "Petraitis", new double[] { 4, 8.33, 3, 6, 7 }, 7));
            studentai.Add(new Studentas("Adomas", "Adomaitis", new double[] {9, 8.7, 10.1, 9, 10 }, 9));
            while (true)
            {

                Console.WriteLine("1.irasyti studentus ");
                Console.WriteLine("2.rodyti studentus ");
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
                    Console.WriteLine("parasykite studento egzamino rezultata: ");
                    double egzRez = Convert.ToDouble(Console.ReadLine());
                    studentai.Add(new Studentas(vardas, pavarde, ndRez, egzRez));
                }
                if (meniu.Equals("2"))
                {
                    Console.WriteLine("Parasykite 'vid' jei norite matyti vidurki arba bet ka kitka jei norite matyti mediana");
                    var meniu2 = Console.ReadLine();
                    if (meniu2.Equals("vid"))
                    {
                        Console.WriteLine(String.Format("{0,-15} {1,-15} {2}", "Vardas", "Pavarde", "Galutinis (Vid.)"));
                        Console.WriteLine("-----------------------------------------------------------------------");
                        foreach (Studentas stud in studentai)
                        {
                            double vidurkis = 0;
                            foreach (double rezul in stud.ndRez)
                            {
                                vidurkis += rezul;
                            }
                            vidurkis = vidurkis / stud.ndRez.Length;
                            double galutinis = 0.3 * vidurkis + 0.7 * stud.egzRez;
                            Console.WriteLine("{0,-15} {1,-15} {2}", stud.vardas, stud.pavarde, Math.Round(galutinis, 2));
                        }
                    }
                    else
                    {
                        Console.WriteLine(String.Format("{0,-15} {1,-15} {2}", "Vardas", "Pavarde", "Galutinis (Med.)"));
                        Console.WriteLine("-----------------------------------------------------------------------");
                        foreach (Studentas stud in studentai)
                        {
                            double mediana = 0;
                            double[] rusiavimas = (double[])stud.ndRez.Clone();
                            Array.Sort(rusiavimas);
                            int mid = stud.ndRez.Length / 2;
                            mediana = (stud.ndRez.Length % 2 != 0) ? (double)rusiavimas[mid] : ((double)rusiavimas[mid] + (double)rusiavimas[mid - 1]) / 2;
                            double galutinis = 0.3 * mediana + 0.7 * stud.egzRez;
                            Console.WriteLine("{0,-15} {1,-15} {2}", stud.vardas, stud.pavarde,Math.Round(galutinis, 2));
                        }
                    }
                }
                if (meniu.Equals("3"))
                {
                    break;
                }

            }

        }
    }
}
