using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ogre;
using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ogre.Tests
{
	[TestClass()]
	public class DaimTests
	{
		[TestMethod()]
		public void TrierPlatTest()
		{
			List<Plat> listPlat = new List<Plat>()
			{
				new Plat{ TypePlat = "Sucrerie", PlatId = 1001, NbrBouchee = 3},
				new Plat{ TypePlat = "Carnivore", PlatId = 1001, NbrBouchee = 4},
				new Plat{ TypePlat = "Végéterien", PlatId = 1001, NbrBouchee = 4}
			};

			Daim bambie = new Daim();
			Plat p = bambie.TrierPlat(listPlat);

			Assert.AreEqual(listPlat[0], p);
		}
	}
}