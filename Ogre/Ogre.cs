using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ogre
{
    public class Ogre
    {
        private readonly object verrou = new object();
        private int platManger;
        public int PlatManger
        {
            get { return platManger; }
            set { platManger = value; }
        }

        public string regime { get; set; }

        public Ogre()
        {
            int PlatManger = 0;
        }
        
        public void SelectPlat()
        {
            ModelesBD.PlatBDContext contexte = new ModelesBD.PlatBDContext();
            try
            {
                // Selectionne puis mange le plat
                ModelesBD.Plat plat = contexte.Plats.FirstOrDefault();                                
                Console.WriteLine("L'ogre a manger le plat : " + plat.TypePlat);
                contexte.Plats.Remove(plat);
                // et attend selon le nombre de bouchée
                Thread.Sleep(plat.NbrBouchee);
                contexte.SaveChanges();                
            }
            catch(Exception e)
            {                
                //Console.WriteLine("Erreur : \n" + e);
            }
        }

        // C'est ici que l'Ogre mange son plat et attends son prochain repas
        public void mangerOgre()
        {
            int x = 0;            

            while(PlatManger < 100)
            {
                lock (verrou)
                {
                    SelectPlat();
                    x++;
                }                
                Thread.Sleep(2000);
                PlatManger++;
                //Console.WriteLine("Un Ogre vient de manger un plat");                
            }
            Console.WriteLine("Total des plats mangés : " + PlatManger);
        }
    }
}
