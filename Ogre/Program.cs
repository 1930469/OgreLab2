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

            for(int i=0; i <1; i++)
            {
                listOgre.Add(new Ogre());

                Thread Ogre1 = new Thread(listOgre[i].mangerOgre);
                Ogre1.Start();                
                Thread Ogre2 = new Thread(listOgre[i].mangerOgre);
                Ogre2.Start();
                Thread Ogre3 = new Thread(listOgre[i].mangerOgre);
                Ogre3.Start();
            }
            Console.WriteLine("Ogre créer");
        }
    }
}
