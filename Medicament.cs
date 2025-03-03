using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{
    class Medicament
    {

        private int iD { get; set; }
        private string nume { get; set; }
        private string producator { get; set; }
        private double pret { get; set; }
        private int cantitate { get; set; }

        public Medicament(int iD, string nume, string producator, double pret, int cantitate)
        {
            this.iD = iD;
            this.nume = nume;
            this.producator = producator;
            this.pret = pret;
            this.cantitate = cantitate;
        }

        public override string ToString()
        {
            return $"{iD}, {nume}, {producator}, {pret}, {cantitate}";
        }

    }
}
