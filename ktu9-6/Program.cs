using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktu9_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tekstas = System.IO.File.ReadAllLines(
                @"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu9-6\ktu9-6\duomenys.txt");
            int savaiciuSkaicius = Convert.ToInt32(tekstas[0]);

            Duomenys[] duomenys = duomenuSuvedimas(tekstas, savaiciuSkaicius);

            Rezultatai[] rezultatai = rezultatuSuvedimas(savaiciuSkaicius, duomenys);

            spausdinimas(rezultatai);
        }

        private static Duomenys[] duomenuSuvedimas(string[] tekstas, int savaiciuSkaicius)
        {
            Duomenys[] duomenys = new Duomenys[savaiciuSkaicius];
            for (int i = 0; i < savaiciuSkaicius; i++)
            {
                string[] eilute = tekstas[i + 1].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                int pirm = Convert.ToInt32(eilute[0]);
                int antr = Convert.ToInt32(eilute[1]);
                int trec = Convert.ToInt32(eilute[2]);
                duomenys[i] = new Duomenys(pirm, antr, trec);
            }
            return duomenys;
        }

        private static Rezultatai[] rezultatuSuvedimas(int savaiciuSkaicius, Duomenys[] duomenys)
        {
            Rezultatai[] rezultatai = new Rezultatai[savaiciuSkaicius + 1];
            int visoValandu = 0;
            int visoDaugiau = 0;
            int visoMaziau = 0;
            for (int i = 0; i < savaiciuSkaicius; i++)
            {
                int valPerSav = duomenys[i].pirm + duomenys[i].antr + duomenys[i].trec;
                int kiekDaugiau = 0;
                int kiekMaziau = 0;
                tikrinimas(duomenys, i, ref kiekDaugiau, ref kiekMaziau);
                visoValandu += valPerSav;
                visoDaugiau += kiekDaugiau;
                visoMaziau += kiekMaziau;
                rezultatai[i] = new Rezultatai(valPerSav, kiekDaugiau, kiekMaziau);
            }
            rezultatai[rezultatai.Length - 1] = new Rezultatai(visoValandu, visoDaugiau, visoMaziau);
            return rezultatai;
        }

        private static void tikrinimas(Duomenys[] duomenys, int i, ref int kiekDaugiau, ref int kiekMaziau)
        {
            if (duomenys[i].pirm > 5)
            {
                kiekDaugiau++;
            }
            else if (duomenys[i].pirm < 5)
            {
                kiekMaziau++;
            }
            if (duomenys[i].antr > 6)
            {
                kiekDaugiau++;
            }
            else if (duomenys[i].antr < 6)
            {
                kiekMaziau++;
            }
            if (duomenys[i].trec > 4)
            {
                kiekDaugiau++;
            }
            else if (duomenys[i].trec < 4)
            {
                kiekMaziau++;
            }
        }

        private static void spausdinimas(Rezultatai[] rezultatai)
        {
            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu9-6\ktu9-6\rezultatai.txt"))
            {
                foreach (Rezultatai rez in rezultatai)
                {
                    file.WriteLine(rez.valPerSav + " " + rez.kiekDaugiau + " " + rez.kiekMaziau);
                }
            }
        }

    }
}
