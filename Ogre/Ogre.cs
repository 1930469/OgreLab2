﻿using Ogre.ModelesBD;
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
        public int PlatManger { get; set; }
        public string regime { get; set; }

        

        // Constructeur
        public Ogre()
        {
            int PlatManger = 0;
        }
        
        // Fonctions
        public Plat SelectPlat()
        {
            ModelesBD.Plat plat = null;
            ModelesBD.PlatBDContext contexte = new ModelesBD.PlatBDContext();
            try
            {
                // Selectionne puis mange le plat
                lock(verrou)
				{
                    plat = contexte.Plats.FirstOrDefault();
                    if(plat != null)
                        contexte.Plats.Remove(plat);

                    contexte.SaveChanges();
                }                
                Thread.Sleep(2000);
                foreach(Plat assietes in contexte.Plats)
                    Console.WriteLine("Plat : " + assietes);

            }
            catch(Exception e)
            {                
                Console.WriteLine("Erreur : \n" + e);
            }
            Thread.Sleep(2000); // A changer

            return plat;
        }

        // C'est ici que l'Ogre mange son plat et attends son prochain repas
        public void mangerOgre()
        {
            while (PlatManger < 100)
            {
                Plat plat = SelectPlat();          
                PlatManger++;          
                if(plat != null)
				{
                    Console.WriteLine("L'ogre a manger le plat : " + plat.TypePlat);
                    Thread.Sleep(plat.NbrBouchee * 1000);
                }
            }

            Console.WriteLine("Total des plats mangés : " + PlatManger);
        }
    }
}
