using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{
    class Medicament
    {

        public int ID { get; set; }
        public string Nume { get; set; }
        public string Producator { get; set; }
        public double Pret  { get; set; }
        public int Cantitate { get; set; }

        public Medicament(int id, string nume, string producator, double pret, int cantitate)
        {
            ID = id;
            Nume = nume;
            Producator = producator;
            Pret = pret;
            Cantitate = cantitate;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Nume: {Nume}, Producator: {Producator}, Pret: {Pret} LEI, Cantitate: {Cantitate}";
        }

    }
}
