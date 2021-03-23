using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Ogre
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ogre> listOgre = new List<Ogre>();

            Ogre ours = new Ours(AfficherPlat);
            listOgre.Add(ours);
            Ogre loup = new Loup(AfficherPlat);
            listOgre.Add(loup);
            Ogre daim = new Daim(AfficherPlat);
            listOgre.Add(daim);
            Ogre serpent = new Serpent(AfficherPlat);
            listOgre.Add(serpent);

            for (int i = 0; i < listOgre.Count; i++)
            {
                Thread ogre = new Thread(listOgre[i].MangerOgre);
                ogre.Start();
            }
            Console.WriteLine("Ogre créer");
            AfficherTable();
        }

        static public void AfficherTable()
        {
            ModelesBD.PlatBDContext contexte = new ModelesBD.PlatBDContext();

            foreach (ModelesBD.Plat plat in contexte.Plats)
                Console.WriteLine("Plat : " + plat);
        }
        static public void AfficherPlat(string Nom,Plat plat)
        {
            Console.WriteLine(Nom + " a manger le plat : " + plat.TypePlat + " (" + plat.NbrBouchee + ")");

        }
    }
}
