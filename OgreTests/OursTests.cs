using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ogre;
using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ogre.Tests
{
	[TestClass()]
	public class OursTests
	{
		[TestMethod()]
		public void TrierPlatTest()
		{
			List<Plat> listPlat = new List<Plat>()
			{
				new Plat{ TypePlat = "Sucrerie", PlatId = 1001, NbrBouchee = 3},
				new Plat{ TypePlat = "Carnivore", PlatId = 1002, NbrBouchee = 4},
				new Plat{ TypePlat = "Végéterien", PlatId = 1003, NbrBouchee = 5},
				new Plat{ TypePlat = "Carnivore", PlatId = 1004, NbrBouchee = 6}
			};

			Ours winnie = new Ours();
			Plat p = winnie.TrierPlat(listPlat);

			// Possibilité de changer la grosseur du plat dans la List pour des tests
			Assert.AreEqual(listPlat[3], p);
		}
	}
}