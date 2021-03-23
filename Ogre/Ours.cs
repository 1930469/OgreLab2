using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ogre
{
    public class Ours : Ogre
    {
        public Ours(Affichage affichePlat) : base(affichePlat)
        {
            Nom = "Winnie";
        }
        public override Plat TrierPlat(IQueryable<Plat> plats)
        {
            var queryMax = plats.Max(p => p.NbrBouchee);
            var queryOurs = plats.Where(p => p.NbrBouchee == queryMax).
                Select(p => p);

            return queryOurs.FirstOrDefault();
        }
    }
}
