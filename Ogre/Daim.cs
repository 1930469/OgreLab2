using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ogre
{
    public class Daim : Ogre
    {
        public Daim()
        {
            Nom = "Bambie";
        }

        public override Plat TrierPlat(IEnumerable<Plat> plats)
        {
            var queryVegetarien = from p in plats
                                  where (p.TypePlat == "Végétarien")
                                  select p;

            var querySucrerie = from p in plats
                                where (p.TypePlat == "Sucrerie")
                                select p;

            if (querySucrerie.Any())
                return querySucrerie.FirstOrDefault();
            else
                return queryVegetarien.FirstOrDefault();
        }
    }
}
