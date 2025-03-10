using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{
    class Angajat
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Functie { get; set; }

        public Angajat(int id, string nume, string functie)
        {
            ID = id;
            Nume = nume;
            Functie = functie;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Nume: {Nume}, Functie: {Functie}";
        }
    }
}
