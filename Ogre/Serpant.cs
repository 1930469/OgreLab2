using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ogre
{
	public class Serpent : Ogre
	{
		public Serpent()
		{
			Nom = "Kaa";
		}
		public Serpent(Affichage affichePlat) : base(affichePlat)
		{
			Nom = "Kaa";
		}

		// Faire des tests sur la fonction TrierPlat
		public override Plat TrierPlat(IEnumerable<Plat> plats)
		{
			var queryMax = plats.Min(p => p.NbrBouchee);
			var querySerpant = plats.Where(p => p.NbrBouchee == queryMax).
				Select(p => p);

			return querySerpant.FirstOrDefault();
		}
	}
}
