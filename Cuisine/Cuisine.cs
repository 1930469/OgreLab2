using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cuisine
{
    public class Cuisine
    {
        public Func<Double> FournisseurDeRandom { get; set; }
        const int PalierViande = 1;
        const int PalierLegume = 6;
        const int NombreRandom = 4;
        public Contexte contexte = new Contexte();

        public void Main()
        {
            //CleanBD();

            bool full = false;            
            Random random = new Random();
            int nbrPlat = contexte.Plats.Count();
            int platCreer = 0;
            FournisseurDeRandom = () => new Random().NextDouble();

            while (!full)
            {
                Thread.Sleep(1000);
                CreePlat(random.Next(1, 10));

                if (nbrPlat == 10)
                    full = true;

                platCreer++;
                AfficherTable();
            }

            AfficherTable();

            Console.WriteLine("table : " + nbrPlat + "\n Plat Créer : " + platCreer);
        }

        public void CreePlat(int choix)
        {
            int valeur = ((int)(-1 * 4 * Math.Log(1 - FournisseurDeRandom())) + 1);            
            Plat p = new Plat();
            if (choix > PalierViande && choix < PalierLegume)
                p.TypePlat = "Carnivore";
            else if (choix == PalierViande)
                p.TypePlat = "Sucrerie";
            else
                p.TypePlat = "Végéterien";

            p.NbrBouchee = valeur;
            contexte.Plats.Add(p);
            contexte.SaveChanges();

        }
        

        public void AfficherTable()
        {
            Contexte contexte = new Contexte();

            foreach (Plat plat in contexte.Plats)
                Console.WriteLine(plat);
        }

        public void CleanBD()
        {
            Contexte context = new Contexte();

            foreach (Plat plat in context.Plats)
            {
                context.Remove(plat);
            }
            context.SaveChanges();
        }

    }
}
