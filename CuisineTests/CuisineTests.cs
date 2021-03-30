
using Cuisine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

namespace Cuisine.Tests
{
    [TestClass()]
    public class CuisineTests
    {
        Random rnd = new Random();
        [TestMethod()]
        public void CreePlatTest()
        {                        
            Mock<Func<Double>> mockRandom = new Mock<Func<Double>>();
            mockRandom.Setup(m => m()).Returns(0.2);  
            
            var data = new List<Plat> 
            {
                new Plat
                {
                    TypePlat = "Carnivore",
                    NbrBouchee = 1
                }                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Plat>>();
            mockSet.As<IQueryable<Plat>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Plat>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Plat>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Plat>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContexte = new Mock<Contexte>();
            mockContexte.Setup(m => m.Plats).Returns(mockSet.Object);
            mockContexte.Setup(m => m.SaveChanges());

            Cuisine c = new Cuisine
            {
                FournisseurDeRandom = mockRandom.Object,
                contexte = mockContexte.Object
            };

            c.CreePlat(5);
            mockContexte.Verify(m => m.Plats.Add(data.FirstOrDefault()), Times.Once);
            mockContexte.Verify(m => m.Plats.Add(It.IsAny<Plat>()), Times.Once);
            mockContexte.Verify(m => m.SaveChanges());
            

        }

            
        
    }
}