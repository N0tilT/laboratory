using Laboratoty.Data.Entities;
using Laboratoty.Data.Services;
using Laboratoty.Data;
using NUnit.Framework.Legacy;
using Microsoft.EntityFrameworkCore;

namespace Labotory.Test
{
    [TestFixture]
    public class PositionServiceTests
    {
        private PositionService _positionService;
        private DbContextOptions<DataContext> _options;

        [OneTimeSetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase($"TestPositionDatabase_{Guid.NewGuid()}")
                .Options;

            using (var context = new DataContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.SaveChanges();
            }

            _positionService = new PositionService(new DataContext(_options));
        }

        [Test]
        public void GetPositions_ShouldReturnAllPositions()
        {
            // Act
            var result = _positionService.GetPositions().ToList();

            // Assert
            ClassicAssert.AreEqual(6, result.Count);
            ClassicAssert.AreEqual("Лаборант", result[0].Title);
            ClassicAssert.AreEqual("Преподаватель", result[1].Title);
        }

        [Test]
        public void GetPosition_ValidId_ShouldReturnPosition()
        {
            // Act
            var result = _positionService.GetPosition(1);

            // Assert
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual("Лаборант", result.Title);
        }

        [Test]
        public void GetPosition_InvalidId_ShouldThrowException()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _positionService.GetPosition(999)); 
        }
    }

}
