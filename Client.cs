﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{

    class Client
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public int Varsta { get; set; }
        public string Adresa { get; set; }


        public Client(int id, string nume, int varsta, string adresa)
        {
            ID = id;
            Nume = nume;
            Varsta = varsta;
            Adresa = adresa;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Nume: {Nume}, Varsta: {Varsta}, Adresa: {Adresa}";
        }
    }
}
