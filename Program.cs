using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacieConsola
{
    class Program
    {
        static Medicament[] medicamente = new Medicament[100];
        static int index = 0;

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int optiune;
            do
            {
                Console.Clear();
                Console.WriteLine("********FARMACIA DANI********");
                Console.WriteLine("1. Administrator");
                Console.WriteLine("2. Cumpărător");
                Console.WriteLine("0. Exit");
                optiune = int.Parse(Console.ReadLine());

                switch (optiune)
                {
                    case 1:
                        ModulAdministrator();
                        break;
                    case 2:
                        ModulCumparator();
                        break;
                }

            } while (optiune != 0);
        }

        static void ModulAdministrator()
        {
            Console.Clear();
            Console.WriteLine("Modul Administrator");
            Console.Write("Introduceți parola (4 cifre): ");
            int parola = int.Parse(Console.ReadLine());

            if (parola != 1234)
            {
                Console.WriteLine("Parolă greșită!");
                Console.ReadKey();
                return;
            }

            int op2;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Introdu medicament nou");
                Console.WriteLine("2. Afișează medicamente");
                Console.WriteLine("0. Înapoi");
                op2 = int.Parse(Console.ReadLine());

                switch (op2)
                {
                    case 1:
                        AdaugaMedicament();
                        break;
                    case 2:
                        AfiseazaMedicamenteDinFisier();
                        break;
                }

            } while (op2 != 0);
        }

        static void ModulCumparator()
        {
            List<Medicament> cos = new List<Medicament>();
            int opt;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Caută medicament");
                Console.WriteLine("2. Finalizează cumpărăturile");
                Console.WriteLine("0. Înapoi");
                opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        Console.Write("Denumire: ");
                        string nume = Console.ReadLine().ToLower();

                        Console.WriteLine("Tip medicament:");
                        Console.WriteLine("1. Capsula");
                        Console.WriteLine("2. Injectie");
                        Console.WriteLine("3. Sirop");
                        Console.Write("Alege tipul: ");
                        int tipOpt = int.Parse(Console.ReadLine());

                        string tip = "";
                        if (tipOpt == 1) tip = "capsula";
                        else if (tipOpt == 2) tip = "injectie";
                        else if (tipOpt == 3) tip = "sirop";

                        bool gasit = false;
                        List<string> toateLiniile = new List<string>(File.ReadAllLines("medicamente.txt"));
                        for (int i = 0; i < toateLiniile.Count; i++)
                        {
                            string linie = toateLiniile[i];
                            string[] tokens = linie.Split(',');
                            if (tokens.Length == 5)
                            {
                                string tipMed = tokens[0].ToLower();
                                string numeMed = tokens[1].ToLower();

                                if (tipMed == tip && numeMed.Contains(nume))
                                {
                                    gasit = true;
                                    double pret = double.Parse(tokens[3]);
                                    int cantitate = int.Parse(tokens[4]);

                                    Console.WriteLine($"Medicament găsit:");
                                    Console.WriteLine($"Tip: {tokens[0]}, Nume: {tokens[1]}, Producător: {tokens[2]}, Preț: {pret:F2} LEI, Cantitate: {cantitate} buc");

                                    if (cantitate == 0)
                                    {
                                        Console.WriteLine("Stoc epuizat.");
                                        break;
                                    }

                                    Console.Write("Doriți să adăugați în coș? (da/nu): ");
                                    string raspuns = Console.ReadLine().ToLower();

                                    if (raspuns == "da")
                                    {
                                        Medicament med = null;
                                        if (tokens[0].ToLower() == "capsula")
                                            med = new Capsula(tokens[1], tokens[2], pret, 1);
                                        else if (tokens[0].ToLower() == "injectie")
                                            med = new Injectie(tokens[1], tokens[2], pret, 1);
                                        else if (tokens[0].ToLower() == "sirop")
                                            med = new Sirop(tokens[1], tokens[2], pret, 1);

                                        if (med != null)
                                        {
                                            cos.Add(med);

                                            // Scade din stoc
                                            cantitate -= 1;
                                            toateLiniile[i] = $"{tokens[0]},{tokens[1]},{tokens[2]},{tokens[3]},{cantitate}";
                                            File.WriteAllLines("medicamente.txt", toateLiniile);

                                            Console.WriteLine("Adăugat în coș și stoc actualizat.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Medicamentul nu a fost adăugat în coș.");
                                    }

                                    break;
                                }
                            }
                        }

                        if (!gasit)
                        {
                            Console.WriteLine("Medicamentul nu a fost găsit.");
                        }

                        Console.ReadKey();
                        break;

                    case 2:
                        double total = 0;
                        Console.Clear();
                        Console.WriteLine("=== Factura ===");
                        foreach (var m in cos)
                        {
                            Console.WriteLine(m);
                            total += m.Pret;
                        }
                        Console.WriteLine($"Total de plată: {total:F2} LEI");
                        Console.ReadKey();
                        break;
                }
            } while (opt != 0);
        }

        static void AdaugaMedicament()
        {
            Console.Clear();
            Console.WriteLine("Tip medicament: 1. Capsula  2. Injectie  3. Sirop");
            int tip = int.Parse(Console.ReadLine());
            Console.Write("Nume: ");
            string nume = Console.ReadLine();
            Console.Write("Producator: ");
            string producator = Console.ReadLine();
            Console.Write("Pret: ");
            double pret = double.Parse(Console.ReadLine());
            Console.Write("Cantitate: ");
            int cantitate = int.Parse(Console.ReadLine());

            Medicament m = null;
            switch (tip)
            {
                case 1: m = new Capsula(nume, producator, pret, cantitate); break;
                case 2: m = new Injectie(nume, producator, pret, cantitate); break;
                case 3: m = new Sirop(nume, producator, pret, cantitate); break;
            }

            medicamente[index++] = m;
            File.AppendAllText("medicamente.txt", m.ToFileFormat() + Environment.NewLine);
            Console.WriteLine("Medicament salvat.");
            Console.ReadKey();
        }

        static void AfiseazaMedicamenteDinFisier()
        {
            Console.Clear();
            if (File.Exists("medicamente.txt"))
            {
                string[] linii = File.ReadAllLines("medicamente.txt");
                foreach (string linie in linii)
                {
                    string[] tokens = linie.Split(',');
                    if (tokens.Length == 5)
                    {
                        string tip = tokens[0];
                        string nume = tokens[1];
                        string producator = tokens[2];
                        double pret = double.Parse(tokens[3]);
                        int cantitate = int.Parse(tokens[4]);

                        Medicament m = null;
                        if (tip == "Capsula")
                            m = new Capsula(nume, producator, pret, cantitate);
                        else if (tip == "Injectie")
                            m = new Injectie(nume, producator, pret, cantitate);
                        else if (tip == "Sirop")
                            m = new Sirop(nume, producator, pret, cantitate);

                        if (m != null)
                            Console.WriteLine(m);
                    }
                }
            }
            else
            {
                Console.WriteLine("Fișierul nu există.");
            }
            Console.ReadKey();
        }
    }
}