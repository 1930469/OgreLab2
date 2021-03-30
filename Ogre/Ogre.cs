using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ogre
{
    public class Ogre
    {
        // Variables 
        private static readonly object verrou = new object();
        public int platManger { get; set; }
        public string Nom { get; set; }
        public delegate void Affichage(string Nom, Plat plat);
        public Affichage afficherPlat;
        public PlatBDContext platContexte;

        // Constructeur 
        public Ogre()
        {
            Nom = "Shrek";
        }

        public Ogre(Affichage affichePlat)
        {
            int platManger = 0;
            Nom = "Shrek";
            afficherPlat += affichePlat;
            platContexte = new PlatBDContext();
        }

        // Fonctions
        public virtual Plat SelectPlat()
        {
            ModelesBD.Plat plat = null;

            try
            {
                SupprimerPlat();

                //foreach(Plat assietes in contexte.Plats)
                //Console.WriteLine("Plat : " + assietes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : \n" + e);
            }
            Thread.Sleep(2000);
            return plat;
        }

        public void SupprimerPlat()
        {
            // Selectionne puis mange le plat
            lock (verrou)
            {
                ModelesBD.Plat plat = TrierPlat(platContexte.Plats);

                if (plat != null)
                    platContexte.Plats.Remove(plat);

                platContexte.SaveChanges();
            }
            Thread.Sleep(2000);
            Console.WriteLine("Plat supprimé");
        }

        public virtual Plat TrierPlat(IEnumerable<Plat> plats)
        {
            return plats.FirstOrDefault();
        }

        // C'est ici que l'Ogre mange son plat et attends son prochain repas
        public void MangerOgre()
        {
            while (platManger < 100)
            {
                Plat plat = SelectPlat();
                platManger++;
                if (plat != null)
                {
                    Console.WriteLine(Nom + " a manger le plat : " + plat.TypePlat + " (" + plat.NbrBouchee + ")");
                    Thread.Sleep(plat.NbrBouchee * 1000);
                }
            }
            Console.WriteLine("Total des plats mangés : " + platManger);
        }
    }
}