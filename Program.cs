using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Medicament med1 = new Medicament(1, "Nurofen", "Reckitt Benckiser", pret: 24.99, 100);
            Client test = new Client(999, "Dani", 20, "Adresa");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Print medicament");
                Console.WriteLine("2. Print client");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "0":
                        return;
                    case "1":
                        Console.WriteLine(med1.ToString());
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine(test.ToString());
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
