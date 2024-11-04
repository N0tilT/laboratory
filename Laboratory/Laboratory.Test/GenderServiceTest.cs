using Laboratoty.Data.Services;
using Laboratoty.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labotory.Test
{
    [TestFixture]
    public class GenderServiceTest
    {
        private GenderService _genderService;
        private DbContextOptions<DataContext> _options;

        [OneTimeSetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase($"TestGenderDatabase_{Guid.NewGuid()}")
                .Options;

            using (var context = new DataContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.SaveChanges();
            }

            _genderService = new GenderService(new DataContext(_options));
        }

        [Test]
        public void GetGenders_ShouldReturnAllPositions()
        {
            // Act
            var result = _genderService.GetGenders().ToList();

            // Assert
            ClassicAssert.AreEqual(2, result.Count);
            ClassicAssert.AreEqual("Мужской", result[0].Title);
            ClassicAssert.AreEqual("Женский", result[1].Title);
        }

        [Test]
        public void GetGender_ValidId_ShouldReturnPosition()
        {
            // Act
            var result = _genderService.GetGender(1);

            // Assert
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual("Мужской", result.Title);
        }

        [Test]
        public void GetGender_InvalidId_ShouldThrowException()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _genderService.GetGender(999));
        }
    }
}
