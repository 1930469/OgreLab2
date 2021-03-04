using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ogre
{
    public class Ours : Ogre
    {
        public Ours()
        {
            Nom = "Winnie";
        }
        public override Plat TrierPlat(IEnumerable<Plat> plats)
        {
            var queryMax = plats.Max(p => p.NbrBouchee);
            var queryOurs = plats.Where(p => p.NbrBouchee == queryMax).
                Select(p => p);

            return queryOurs.FirstOrDefault();
        }
    }
}
