using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{
    public abstract class Medicament
    {
        public string Tip => this.GetType().Name;
        public string Nume { get; set; }
        public string Producator { get; set; }
        public double Pret { get; set; }
        public int Cantitate { get; set; }

        protected Medicament(string nume, string producator, double pret, int cantitate)
        {
            Nume = nume;
            Producator = producator;
            Pret = pret;
            Cantitate = cantitate;
        }

        public override string ToString() =>
    $"Tip: {Tip}, Nume: {Nume}, Producător: {Producator}, Preț: {Pret} LEI, Cantitate: {Cantitate} buc";

        public string ToFileFormat() => $"{Tip},{Nume},{Producator},{Pret},{Cantitate}";
    }
}
