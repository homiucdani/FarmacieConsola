using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{

    class Client
    {
        private int iD { get; set; }
        private string nume{ get; set; }
        private int varsta { get; set; }
        private string adresa{ get; set; }


        public Client(int iD, string nume, int varsta, string adresa)
        {
            this.iD = iD;
            this.nume = nume;
            this.varsta = varsta;
            this.adresa = adresa;
        }

        public override string ToString()
        {
            return $"{iD}, {nume}, {varsta}, {adresa}";
        }
    }
}
