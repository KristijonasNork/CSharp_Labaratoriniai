using System;
using System.Collections.Generic;
using System.IO;

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
                Console.WriteLine("3.nuskaitymas i6 failo ir jo vaizdavimas");
                Console.WriteLine("4.iseiti ");
                var meniu = Console.ReadLine();
                if (meniu.Equals("1")) {
                    Random rnd = new Random();
                    Console.WriteLine("parasykite studento varda: ");
                    var vardas = Console.ReadLine();
                    Console.WriteLine("parasykite studento pavarde: ");
                    var pavarde = Console.ReadLine();
                    double balas = 0;
                    List<double> balai = new List<double>();
                    Console.WriteLine("ar norite kad studento balai butu sugeneruojami? 1- taip, bet koks kitas skaicius/simbolis -ne");
                    var meniuBal = Console.ReadLine();
                    if (meniuBal.Equals("1"))
                    {
                        //bus sukuriama 1-8 skaiciu nuo 1 iki 10.
                        int randnumber = rnd.Next(1, 9);
                        for (int ctr = 0; ctr < randnumber ; ctr++)
                        {
                            balai.Add(rnd.Next(1, 11));
                            //Console.WriteLine(balai[ctr]);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("parasykite studento balus, kai baigsite parasykite -1: ");
                        while (balas != -1)
                        {
                            balas = Convert.ToDouble(Console.ReadLine());
                            if (balas != -1)
                            {
                                balai.Add(balas);
                            }
                        }
                    }
                    double[] ndRez = new double[balai.Count];
                    int i = 0;
                    foreach(double bal in balai)
                    {
                        ndRez[i] = bal;
                        i++;
                    }
                    Console.WriteLine("ar norite kad studento egzamino rezultatas butu sugeneruojamas? 1- taip, bet koks kitas skaicius/simbolis -ne");
                    var meniuRez = Console.ReadLine();
                    double egzRez = 0;
                    if (meniuRez.Equals("1"))
                    {
                        egzRez = rnd.Next(1, 11);
                    }
                    else
                    {
                        egzRez = Convert.ToDouble(Console.ReadLine());
                    }
                    studentai.Add(new Studentas(vardas, pavarde, ndRez, egzRez));
                }
                if (meniu.Equals("2"))
                {
                    Console.WriteLine(String.Format("{0,-15} {1,-15} {2, -18} {3}", "Vardas", "Pavarde", "Galutinis (Vid.)", "Galutinis (Med.)" ));
                    Console.WriteLine("-----------------------------------------------------------------------");
                    studentai.Sort((x, y) => x.vardas.CompareTo(y.vardas));
                    foreach (Studentas stud in studentai)
                    {
                        double vidurkis = 0;
                        double mediana = 0;
                        foreach (double rezul in stud.ndRez)
                        {
                            vidurkis += rezul;
                        }
                        vidurkis = vidurkis / stud.ndRez.Length;

                        double[] rusiavimas = (double[])stud.ndRez.Clone();
                        Array.Sort(rusiavimas);
                        int mid = stud.ndRez.Length / 2;
                        mediana = (stud.ndRez.Length % 2 != 0) ? (double)rusiavimas[mid] : ((double)rusiavimas[mid] + (double)rusiavimas[mid - 1]) / 2;
                        double galutinis = 0.3 * mediana + 0.7 * stud.egzRez;
                        double galutinis2 = 0.3 * vidurkis + 0.7 * stud.egzRez;
                        Console.WriteLine("{0,-15} {1,-15} {2,9} {3, 18}", stud.vardas, stud.pavarde,Math.Round(galutinis2, 2), Math.Round(galutinis, 2));
                    }
                }
                if (meniu.Equals("3")) {
                    Console.WriteLine("Parasykite kelia iki norimo failo.");
                    string tempFailas = Console.ReadLine();
                    if (File.Exists(tempFailas))
                    {
                        using (StreamReader sr = new StreamReader(tempFailas))
                        {
                            string line = sr.ReadLine();
                            while (!string.IsNullOrEmpty((line = sr.ReadLine())))
                            {
                                // Vardas Pavardė ND1 ND2 ND3 ND4 ND5 Egzaminas
                                var reiksmes = line.Split(" ");
                                var vardas = reiksmes[0];
                                var pavarde = reiksmes[1];
                                Console.WriteLine(reiksmes);
                                double[] namuDarbai = new double[5] { Convert.ToDouble(reiksmes[2]) , Convert.ToDouble(reiksmes[3]), Convert.ToDouble(reiksmes[4]), Convert.ToDouble(reiksmes[5]), Convert.ToDouble(reiksmes[6]) };
                                double egzBalas = Convert.ToDouble(reiksmes[7]);
                                studentai.Add(new Studentas(vardas, pavarde, namuDarbai, egzBalas));
                                // C:\Users\Kristijonas\source\repos\Labaratoriniai_csharp\Labaratoriniai_csharp\Studentai.txt
                                Console.WriteLine("pridetasstudentas " + vardas + " " + pavarde);
                            }
                        }
                        Console.WriteLine("Failas egzistuoja ir yra ikeltas.");
                    }
                    else
                    {
                        Console.WriteLine("Failas neegzistuoja.");
                    }
                }
                if (meniu.Equals("4"))
                {
                    break;
                }

            }

        }
    }
}
