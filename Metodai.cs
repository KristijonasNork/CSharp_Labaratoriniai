using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Labaratoriniai_csharp
{
    public class Metodai
    {
        public List<Studentas> ReadFromFile()
        {
            var studentai = new List<Studentas>();
            Console.WriteLine("Parasykite kelia iki norimo failo.");
            string tempFailas = Console.ReadLine();
            if (File.Exists(tempFailas))
            {
                using (StreamReader sr = new StreamReader(tempFailas))
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
                            Console.WriteLine(reiksmes);
                            double[] namuDarbai = new double[5] { Convert.ToDouble(reiksmes[2]), Convert.ToDouble(reiksmes[3]), Convert.ToDouble(reiksmes[4]), Convert.ToDouble(reiksmes[5]), Convert.ToDouble(reiksmes[6]) };
                            double egzBalas = Convert.ToDouble(reiksmes[7]);
                            studentai.Add(new Studentas(vardas, pavarde, namuDarbai, egzBalas));
                            // C:\Users\Kristijonas\source\repos\Labaratoriniai_csharp\Labaratoriniai_csharp\Studentai.txt
                            Console.WriteLine("pridetasstudentas " + vardas + " " + pavarde);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("blogai suformatuotas failas");
                            break;
                        }
                        Console.WriteLine("Failas egzistuoja ir yra ikeltas.");
                    }
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
            }
        }
    }
}
