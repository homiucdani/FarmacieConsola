using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{
    class Tranzactie
    {
        public int ID { get; set; }
        public Client Client { get; set; }
        public Medicament Medicament { get; set; }
        public Angajat Angajat { get; set; }
        public int Cantitate { get; set; }
        public DateTime DataTranzactie { get; set; }

        public Tranzactie(int id, Client client, Medicament medicament, Angajat angajat, int cantitate)
        {
            ID = id;
            Client = client;
            Medicament = medicament;
            Angajat = angajat;
            Cantitate = cantitate;
            DataTranzactie = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Tranzactie ID: {ID}, Client: {Client.Nume}, Medicament: {Medicament.Nume}, Cantitate: {Cantitate}, Angajat: {Angajat.Nume}, Data: {DataTranzactie}";
        }
    }
}
