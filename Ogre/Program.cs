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

            for(int i=0; i <3; i++)
            {
                listOgre.Add(new Ogre());

                Thread Ogre1 = new Thread(listOgre[i].mangerOgre);
                Ogre1.Start();                
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
    }
}
