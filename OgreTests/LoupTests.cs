using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ogre;
using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ogre.Tests
{
	[TestClass()]
	public class LoupTests
	{
		[TestMethod()]
		public void TrierPlatTest()
		{
			List<Plat> listPlat = new List<Plat>()
			{
				new Plat{ TypePlat = "Sucrerie", PlatId = 1001, NbrBouchee = 3},
				new Plat{ TypePlat = "Carnivore", PlatId = 1002, NbrBouchee = 5},
				new Plat{ TypePlat = "Végéterien", PlatId = 1003, NbrBouchee = 4}
			};

			Loup CrocBlanc = new Loup();
			Plat p = CrocBlanc.TrierPlat(listPlat);

			Assert.AreEqual(listPlat[0], p);    // Plat Sucrerie
												//Assert.AreEqual(listPlat[1],p);   // Plat Carnivore
		}
	}
}