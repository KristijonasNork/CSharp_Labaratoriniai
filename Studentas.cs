using System;
using System.Collections.Generic;
using System.Text;

namespace Labaratoriniai_csharp
{
    public class Studentas
    {
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
}
