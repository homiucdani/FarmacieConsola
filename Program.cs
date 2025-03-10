using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{
    class Program
    {

        static List<Medicament> medicamente = new List<Medicament>();
        static List<Client> clienti = new List<Client>();
        static List<Angajat> angajati = new List<Angajat>();

        static void Main(string[] args)
        {

            angajati.Add(new Angajat(1, "Dani", "Farmacist"));
            clienti.Add(new Client(1001, "Doe", 32, "Str. ABC"));
            medicamente.Add(new Medicament(1, "Paracetamol", "Para", 10.5, 10));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Adaugare client");
                Console.WriteLine("2. Adaugare angajat");
                Console.WriteLine("3. Adaugare medicament");
                Console.WriteLine("4. Afisare date");
                Console.WriteLine("5. Cautare");
                Console.Write("Alegeti o optiune: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "0":
                        return;
                    case "1":
                        AdaugaClient();
                        break;
                    case "2":
                        AdaugaAngajat();
                        break;
                    case "3":
                        AdaugaMedicament();
                        break;
                    case "4":
                        AfisareDate();
                        break;
                    case "5":
                        Cautare();
                        break;
                }
            }
        }

        static void AdaugaClient()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nume: ");
            string nume = Console.ReadLine();
            Console.Write("Varsta: ");
            int varsta = int.Parse(Console.ReadLine());
            Console.Write("Adresa: ");
            string adresa = Console.ReadLine();
            clienti.Add(new Client(id, nume, varsta, adresa));
        }

        static void AdaugaAngajat()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nume: ");
            string nume = Console.ReadLine();
            Console.Write("Rol: ");
            string rol = Console.ReadLine();
            angajati.Add(new Angajat(id, nume, rol));
        }

        static void AdaugaMedicament()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nume: ");
            string nume = Console.ReadLine();
            Console.Write("Producator: ");
            string producator = Console.ReadLine();
            Console.Write("Pret: ");
            double pret = double.Parse(Console.ReadLine());
            Console.Write("Cantitate: ");
            int cantitate = int.Parse(Console.ReadLine());
            medicamente.Add(new Medicament(id, nume, producator, pret, cantitate));
        }

        static void AfisareDate()
        {
            Console.WriteLine("-------- Clienti --------");
            foreach (var client in clienti) Console.WriteLine(client);

            Console.WriteLine("-------- Angajati -------");
            foreach (var angajat in angajati) Console.WriteLine(angajat);

            Console.WriteLine("------- Medicamente ----------");
            foreach (var medicament in medicamente) Console.WriteLine(medicament);

            Console.ReadLine();
        }

        static void Cautare()
        {
            Console.Write("Introduceti numele: ");
            string nume = Console.ReadLine().ToLower();
            var rezultateClienti = clienti.FindAll(c => c.Nume.ToLower().Contains(nume));
            var rezultateAngajati = angajati.FindAll(a => a.Nume.ToLower().Contains(nume));
            var rezultateMedicamente = medicamente.FindAll(m => m.Nume.ToLower().Contains(nume));

            Console.WriteLine("--- Clienti gasiti ---");
            foreach (var client in rezultateClienti) Console.WriteLine(client);

            Console.WriteLine("--- Angajati gasiti ---");
            foreach (var angajat in rezultateAngajati) Console.WriteLine(angajat);

            Console.WriteLine("--- Medicamente gasite ---");
            foreach (var medicament in rezultateMedicamente) Console.WriteLine(medicament);

            Console.ReadLine();
        }
    }
}
