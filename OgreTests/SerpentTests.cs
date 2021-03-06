﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Text;
using static Ogre.Ogre;

namespace Ogre.Tests
{
	[TestClass()]
	public class SerpentTests
	{
		[TestMethod()]
		public void TrierPlatTest()
		{
			List<Plat> listPlat = new List<Plat>()
			{
				new Plat{ TypePlat = "Sucrerie", PlatId = 1001, NbrBouchee = 3},
				new Plat{ TypePlat = "Carnivore", PlatId = 1001, NbrBouchee = 4},
				new Plat{ TypePlat = "Végéterien", PlatId = 1001, NbrBouchee = 4},
				new Plat{ TypePlat = "Carnivore", PlatId = 1001, NbrBouchee = 4},
				new Plat{ TypePlat = "Sucrerie", PlatId = 1001, NbrBouchee = 4},
				new Plat{ TypePlat = "Végéterien", PlatId = 1001, NbrBouchee = 4}
			};

			Serpent kaa = new Serpent();
			Plat p = kaa.TrierPlat(listPlat);

			Assert.AreEqual(listPlat[0], p);
		}
	}
}