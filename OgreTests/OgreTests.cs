using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ogre;
using Ogre.ModelesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ogre.Tests
{
	[TestClass()]
	public class OgreTests
	{
		public delegate void Affichage(string Nom, Plat plat);
		public Affichage afficherPlat;

		public void AfficherTest(string nom, Plat plat)
		{
			Console.WriteLine(nom + " a manger le plat : " + plat.TypePlat + " (" + plat.NbrBouchee + ")");
		}

		[TestMethod()]
		public void SupprimerPlatTest()
		{
			// Creation de la liste
			var data = new List<Plat>()
			{
				new Plat{ TypePlat="Carnivore", NbrBouchee = 5, PlatId=1001},
				new Plat{ TypePlat="Sucrerie", NbrBouchee = 3, PlatId=1002},
			}.AsQueryable();

			Plat p = new Plat
			{
				TypePlat = "Carnivore",
				PlatId = 1001,
				NbrBouchee = 5
			};

			// Mocking le contexte
			var mockSet = new Mock<DbSet<Plat>>();
			mockSet.As<IQueryable<Plat>>().Setup(m => m.Provider).Returns(data.Provider);
			mockSet.As<IQueryable<Plat>>().Setup(m => m.Expression).Returns(data.Expression);
			mockSet.As<IQueryable<Plat>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mockSet.As<IQueryable<Plat>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

			var mockContexte = new Mock<PlatBDContext>();
			mockContexte.Setup(m => m.Plats).Returns(mockSet.Object);
			mockContexte.Setup(m => m.SaveChanges());

			Ogre ogreTest = new Ogre()
			{
				platContexte = mockContexte.Object
			};

			ogreTest.SupprimerPlat();

			mockContexte.Verify(m => m.Plats.Remove(p), Times.Once);
			mockContexte.Verify(m => m.Plats.Remove(It.IsAny<Plat>()), Times.Once);
			mockContexte.Verify(m => m.SaveChanges());

		}
	}
}