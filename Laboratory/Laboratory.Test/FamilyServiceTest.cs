using Laboratoty.Data.Services;
using Laboratoty.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratoty.Data.Entities;

namespace Labotory.Test
{
    [TestFixture]
    internal class FamilyServiceTest
    {
        private FamilyService _familyService;
        private DbContextOptions<DataContext> _options;

        [OneTimeSetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase($"TestFamilyDatabase_{Guid.NewGuid()}")
                .Options;

            using (var context = new DataContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.SaveChanges();
            }

            _familyService = new FamilyService(new DataContext(_options));
        }

        [Test]
        public void GetFamilies_ShouldReturnAllPositions()
        {
            // Act
            var result = _familyService.GetFamilies().ToList();

            // Assert
            ClassicAssert.AreEqual(3, result.Count);
            ClassicAssert.AreEqual("Не женат/не замужем", result[0].Title);
            ClassicAssert.AreEqual("Женат/Замужем", result[1].Title);
            ClassicAssert.AreEqual("Разведен(-а)", result[2].Title);

        }

        [Test]
        public void GetFamily_ValidId_ShouldReturnPosition()
        {
            // Act
            var result = _familyService.GetFamily(1);

            // Assert
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual("Не женат/не замужем", result.Title);
        }

        [Test]
        public void GetFamily_InvalidId_ShouldThrowException()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _familyService.GetFamily(999));
        }
    }
}
