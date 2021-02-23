using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cuisine
{
	public class Cuisine
	{
         private Random rnd = new Random();

        public void Main()
		{
            CleanBD();

            bool full = false;
            Contexte contexte = new Contexte();
            Random random = new Random();
            int nbrPlat = contexte.Plats.Count();
            int platCreer = 0;

            while (!full)
            {
                Thread.Sleep(1000);
                CreePlat(random.Next(1, 4));

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
            int valeur = (int)(-1 * 5 * Math.Log(1 - rnd.NextDouble()));
            Contexte contexte = new Contexte();
            switch (choix)
            {
                case 1:
                    Plat platCochon = new Plat
                    {
                        TypePlat = "Cochon",
                        NbrBouchee = valeur
                    };
                    contexte.Plats.Add(platCochon); contexte.SaveChanges(); break;
                case 2:
                    Plat platVache = new Plat
                    {
                        TypePlat = "Vache",
                        NbrBouchee = valeur
                    };
                    contexte.Plats.Add(platVache); contexte.SaveChanges(); break;
                case 3:
                    Plat platPoulet = new Plat
                    {
                        TypePlat = "Poulet",
                        NbrBouchee = valeur
                    };
                    contexte.Plats.Add(platPoulet); contexte.SaveChanges(); break;
            }
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
