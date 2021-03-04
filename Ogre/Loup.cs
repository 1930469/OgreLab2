using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ogre
{
    public class Loup : Ogre
    {
        public Loup()
        {
            Nom = "Croc Blanc";
        }

        public override Plat TrierPlat(IEnumerable<Plat> plats)
        {
            var queryCarnivore = from p in plats
                                 where (p.TypePlat == "Carnivore")
                                 select p;

            var querySucrerie = from p in plats
                                where (p.TypePlat == "Sucrerie")
                                select p;

            if (querySucrerie.Any())
                return querySucrerie.FirstOrDefault();
            else
                return queryCarnivore.FirstOrDefault();
        }
    }
}
