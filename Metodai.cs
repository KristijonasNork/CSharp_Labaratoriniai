using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Labaratoriniai_csharp
{
    public class Metodai
    {
        public List<Studentas> ReadFromFile(string filePath = "C:/Users/Kristijonas/source/repos/Labaratoriniai_csharp/Labaratoriniai_csharp/Studentai.txt")
        {
            var studentai = new List<Studentas>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    while (!string.IsNullOrEmpty((line = sr.ReadLine())))
                    {
                        try
                        {
                            // Vardas Pavardė ND1 ND2 ND3 ND4 ND5 Egzaminas
                            var reiksmes = line.Split(" ");
                            var vardas = reiksmes[0];
                            var pavarde = reiksmes[1];
                            //Console.WriteLine(reiksmes);
                            double[] namuDarbai = new double[5] { Convert.ToDouble(reiksmes[2]), Convert.ToDouble(reiksmes[3]), Convert.ToDouble(reiksmes[4]), Convert.ToDouble(reiksmes[5]), Convert.ToDouble(reiksmes[6]) };
                            double egzBalas = Convert.ToDouble(reiksmes[7]);
                            studentai.Add(new Studentas(vardas, pavarde, namuDarbai, egzBalas));
                            // C:\Users\Kristijonas\source\repos\Labaratoriniai_csharp\Labaratoriniai_csharp\Studentai.txt
                            //Console.WriteLine("pridetasstudentas " + vardas + " " + pavarde);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("blogai suformatuotas failas");
                            break;
                        }
                        
                    }
                    Console.WriteLine("Failas egzistuoja ir yra ikeltas.");
                }
            }
            else
            {
                Console.WriteLine("Failas neegzistuoja.");
            }
            return studentai;
        }

        public void generuotiFailus()
        {
            Random rnd = new Random();
            for (int i = 1; i <= 5; i++)
            {
                Stopwatch laikmatis = new Stopwatch();
                laikmatis.Start();
                using (StreamWriter file = new StreamWriter("C:/Users/Kristijonas/source/repos/Labaratoriniai_csharp/Labaratoriniai_csharp/studentai" + i + ".txt"))
                {
                    
                    for (int j = 1; j <= Math.Pow(10, i+1); j++) // kuriami bus nuo 100 o ne nuo 1000 taupant kompiuterio resursus
                    {
                        string vardas = "Vardas" + j;
                        string pavarde = "Pavarde" + j;
                        int egzRez = rnd.Next(1, 11);
                        double[] ndRez = new double[5];
                        for (int n = 0; n < 5; n++)
                            ndRez[n] = rnd.Next(1, 11);
                        Studentas studentas = new Studentas(vardas, pavarde, ndRez, egzRez);
                        file.WriteLine(studentas.ToString());
                    }

                }
                laikmatis.Stop();
                Console.WriteLine(((double)laikmatis.ElapsedMilliseconds / 1000) + " s");

            }
        }
        public void rusiuotiFailus()
        {
            using (StreamWriter file = new StreamWriter("C:/Users/Kristijonas/source/repos/Labaratoriniai_csharp/Labaratoriniai_csharp/nuskriaustukai.txt")) { 

                using (StreamWriter file2 = new StreamWriter("C:/Users/Kristijonas/source/repos/Labaratoriniai_csharp/Labaratoriniai_csharp/kietiakiai.txt")) { 
                    for (int i = 1; i <= 5; i++)
                    {
                        Stopwatch laikmatis = new Stopwatch();
                        laikmatis.Start();
                        foreach (Studentas stud in ReadFromFile("C:/Users/Kristijonas/source/repos/Labaratoriniai_csharp/Labaratoriniai_csharp/studentai" + i + ".txt"))
                        {
                            double vidurkis = 0;
                            foreach (double rezul in stud.ndRez)
                            {
                                vidurkis += rezul;
                            }
                            vidurkis = vidurkis / stud.ndRez.Length;
                            double galutinis = 0.3 * vidurkis + 0.7 * stud.egzRez;
                            if (galutinis < 5)
                            {
                                file.WriteLine(stud.ToString());
                            }
                            else
                            {
                                file2.WriteLine(stud.ToString());
                            }
                        }
                        laikmatis.Stop();
                        Console.WriteLine(((double)laikmatis.ElapsedMilliseconds / 1000) + " s. Studentai" + i + ".txt");
                    }
                }

            }
        }
    }
}
