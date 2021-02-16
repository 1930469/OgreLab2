using System;
using System.Linq;
using System.Threading;

namespace Cuisine
{
    class Cuisine
    {
        static public void CreePlat(int choix)
        {
            Contexte contexte = new Contexte();
            
            switch (choix)
            {
                case 1: Plat platCochon = new Plat
                        {
                            TypePlat = "Cochon",
                            NbrBouchee = 3
                        }; 
                    contexte.Plats.Add(platCochon); contexte.SaveChanges(); break;
                case 2: Plat platVache = new Plat
                        {
                            TypePlat = "Vache",
                            NbrBouchee = 1
                        }; 
                    contexte.Plats.Add(platVache); contexte.SaveChanges(); break;
                case 3: Plat platPoulet = new Plat
                        {
                            TypePlat = "Poulet",
                            NbrBouchee = 2
                        }; 
                    contexte.Plats.Add(platPoulet); contexte.SaveChanges(); break;
                
            }
        }

        static public void AfficherTable()
        {
            Contexte contexte = new Contexte();

            foreach (Plat plat in contexte.Plats)
                Console.WriteLine(plat);
        }

        static public void CleanBD()
        {
            Contexte context = new Contexte();

            foreach (Plat plat in context.Plats)
                context.Plats.Remove(plat);

            context.SaveChanges();
            Console.WriteLine("Plat supprimé : " + context.Plats.Count());
        }

        static void Main(string[] args)
        {
            CleanBD();

            bool full = false;
            Contexte contexte = new Contexte();
            Random random = new Random();
            int nbrPlat = contexte.Plats.Count();
            int platCreer = 0;
            
            while (full == false)
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
    }
}