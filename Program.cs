using System;
using System.Collections.Generic;
using System.IO;

namespace Labaratoriniai_csharp
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Studentas> studentai = new List<Studentas>();
            studentai.Add(new Studentas("Tomas", "Petraitis", new double[] { 4, 8.33, 3, 6, 7 }, 7));
            studentai.Add(new Studentas("Adomas", "Adomaitis", new double[] {9, 8.7, 10, 9, 10 }, 9));
            Metodai m = new Metodai();
            while (true)
            {

                Console.WriteLine("1.irasyti studentus ");
                Console.WriteLine("2.rodyti studentus "); 
                Console.WriteLine("3.nuskaitymas is failo ir jo vaizdavimas");
                Console.WriteLine("4.sukurti 5 failus ");
                Console.WriteLine("5.iseiti ");
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
                            Console.WriteLine(balai[ctr]);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("parasykite studento balus nuo 1 iki 10, kai baigsite parasykite -1: ");
                        while (balas != -1)
                        {
                            try
                            {
                                balas = Convert.ToDouble(Console.ReadLine());
                                if (balas != -1 && (1 <= balas) && (balas <= 10))
                                {
                                    balai.Add(balas);
                                }
                                else
                                {
                                    Console.Write("blogai parasytas skaicius todel neisaugomas");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                Console.WriteLine("blogai parasytas balas");
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
                        try
                        {
                            while(((1 <= egzRez) && (egzRez <= 10)))
                            {
                                egzRez = Convert.ToDouble(Console.ReadLine());
                                if(((1 <= egzRez) && (egzRez <= 10)))
                                {
                                    Console.WriteLine("blogas skaicius");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("blogai parasytas rezultatas");
                        }
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
                    foreach (Studentas s in m.ReadFromFile())
                        studentai.Add(s);
                    Console.WriteLine("Pridėti studentai");
                }
                if (meniu.Equals("4"))
                {
                    m.generuotiFailus();
                }
                if (meniu.Equals("5"))
                {
                    break;
                }

            }

        }
    }
}
