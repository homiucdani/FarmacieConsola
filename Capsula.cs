using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{
    public class Capsula : Medicament
    {
        public Capsula(string nume, string producator, double pret, int cantitate)
            : base(nume, producator, pret, cantitate) { }
    }
}
