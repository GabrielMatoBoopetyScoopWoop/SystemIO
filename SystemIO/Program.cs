using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            int birac;
            do
            {
                Console.Write("Ima 8 različitih kodova koji se biraju upisom od 1 do 8 gdje je 0 kraj programa:");
                birac = Convert.ToInt32(Console.ReadLine());
                switch (birac)
                {
                    case 1:
                        Console.Write("Unesite putanju direktorija: ");
                        string putanja = Console.ReadLine();
                        // Provjeravamo postoji li uneseni direktorij
                        if (Directory.Exists(putanja))
                        {
                            // Ispisujemo sve datoteke u direktoriju
                            Console.WriteLine("Datoteke:");
                            foreach (string Datoteka in Directory.GetFiles(putanja))
                            {
                                Console.WriteLine(Datoteka);
                            }
                            // Provjeravamo postoji li poddirektorij TEST
                            string putanjaPoddirektorija = putanja + "\\TEST";
                            if (!Directory.Exists(putanjaPoddirektorija))
                            {
                                // Ako ne postoji, kreiramo ga
                                Directory.CreateDirectory(putanjaPoddirektorija);
                            }
                            // Ispisujemo sve poddirektorije
                            Console.WriteLine("Poddirektoriji:");
                            foreach (string poddirektorij
                            in Directory.GetDirectories(putanja))
                            {
                                Console.WriteLine(poddirektorij);
                            }
                            // Brišemo poddirektorij TEST
                            Directory.Delete(putanjaPoddirektorija);
                            // Ponovno ispisujemo sve poddirektorije
                            Console.WriteLine("Nakon brisanja direktorija TEST:");
                            foreach (string poddirektorij
                            in Directory.GetDirectories(putanja))
                            {
                                Console.WriteLine(poddirektorij);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Putanja ne postoji na računalu!");
                        }
                        Console.ReadKey();
                break;
                    case 2:
                        Console.Write("Unesite Vaše ime: ");
                        string ime = Console.ReadLine();
                        string datoteka = "ime.txt";
                        // Provjeravamo postoji li datoteka ime.txt
                        if (File.Exists(datoteka))
                        {
                            // Ako postoji kopiramo ju u backup direktorij
                            if (!Directory.Exists("backup"))
                            {
                                Directory.CreateDirectory("backup");
                            }
                            File.Copy(datoteka, "backup\\ime_"+DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")+ ".txt");
                            // Brišemo tu datoteku
                            File.Delete(datoteka);
                        }
                        // U datoteku spremamo novo ime
                        File.WriteAllText(datoteka, ime);
                        break;
                    case 3:
                        Console.Write("Unesite putanju izvornog direktorija:");
                        string izvorniDirektorij = Console.ReadLine();
                        Console.Write("Unesite putanju ciljnog direktorija:");
                        string ciljniDirektorij = Console.ReadLine();
                        try
                        {
                            // Kopiramo sve datoteke iz izvornog u ciljni direktorij
                        foreach (string Datoteka in Directory.GetFiles(izvorniDirektorij))
                            {
                                // Dohvaćamo ime datoteke (bez putanje)
                                string imeDatoteke = Path.GetFileName(Datoteka);
                                // Kreiramo putanju ciljne datoteke
                                string ciljnaDatoteka
                                = Path.Combine(ciljniDirektorij,

                                imeDatoteke);

                                // Kopiramo datoteku s izvorne na ciljnu putanju
                                File.Copy(Datoteka, ciljnaDatoteka, true);
                            }
                            Console.WriteLine("Gotovo!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Greška: { 0}", ex.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Write("Unesite putanju direktorija: ");
                        putanja = Console.ReadLine();
                        // Instanciramo DirectoryInfo objekt
                        DirectoryInfo diIzvor = new DirectoryInfo(putanja);
                        // Ispisujemo sve poddirektorije
                        Console.WriteLine("\n-- Poddirektoriji:");
                        foreach (DirectoryInfo di in diIzvor.GetDirectories())
                        {
                        Console.WriteLine("{ 0}\t{ 1}\t{ 2}",di.Name, di.CreationTime, di.LastAccessTime);
                        }
                        // Ispisujemo sve datoteke
                        Console.WriteLine("\n-- Datoteke:");
                        foreach (FileInfo fi in diIzvor.GetFiles())
                        {
                            Console.WriteLine("{ 0}\t{ 1}\t{ 2}", fi.Name, fi.CreationTime, fi.LastAccessTime);
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Write("Unesite ime: ");
                        ime = Console.ReadLine();
                        Console.Write("Unesite prezime: ");
                        string prezime = Console.ReadLine();
                        StreamWriter sw = new StreamWriter(@"D:\My Documents\NOOP\datoteka.txt");
                        sw.WriteLine("Ime: { 0}", ime);
                        sw.WriteLine("Prezime: { 0}", prezime);
                        sw.Close();
                        break;
                    case 6:
                        StreamReader sr = new StreamReader(@"D:\My Documents\NOOP\datoteka.txt");
                        // Čitamo datoteku liniju po liniju
                        while (!sr.EndOfStream)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                        // Zatvaramo datoteku
                        sr.Close();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Write("Unesite ime: ");
                        ime = Console.ReadLine();
                        Console.Write("Unesite prezime: ");
                        prezime = Console.ReadLine();
                        // Podatke upisujemo u datoteku
                        Console.WriteLine("\n-- Zapisujemo u datoteku...");
                        using (StreamWriter Sw = new StreamWriter(@"D:\My Documents\NOOP\datoteka.txt"))
                        {
                            Sw.WriteLine("Ime: { 0}", ime);
                            Sw.WriteLine("Prezime: { 0}", prezime);
                        }
                        // Podatke čitamo iz datoteke
                        Console.WriteLine("\n-- Pročitano iz datoteke:");
                        using (StreamReader Sr = new StreamReader(@"D:\My Documents\NOOP\datoteka.txt"))
                        {
                            while (!Sr.EndOfStream)
                            {
                                Console.WriteLine(Sr.ReadLine());
                            }
                        }
                        Console.ReadKey();
                        break;
                }
            } while (birac != 0);
        }
    }
}
