using Laboratoty.Data.Services;
using Laboratoty.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratoty.Data.DTOs;
using NUnit.Framework.Legacy;
using Laboratoty.Data.Entities;
using Laboratoty.Data.Mapper;

namespace Labotory.Test
{
    [TestFixture]
    public class UserServiceTest
    {
        private UserService _userService;
        private DbContextOptions<DataContext> _options;

        [OneTimeSetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase($"TestUserDatabase_{Guid.NewGuid()}")
                .Options;

            using (var context = new DataContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated(); 
                var addUserDto = new AddUserDto
                (
                    "John",
                    "A.",
                    "Doe",
                    30,
                    true,
                    2,
                    1,
                    1,
                    new Position { Title = "Developer" },
                    new Gender { Title = "Male" },
                    new Family { Title = "Doe Family" }
                );
                context.Users.Add(addUserDto.ToEntity());
                var addUserDto2 = new AddUserDto
                (
                    "Jane",
                    "A.",
                    "Doe",
                    30,
                    true,
                    2,
                    1,
                    1,
                    new Position { Title = "Developer" },
                    new Gender { Title = "Male" },
                    new Family { Title = "Doe Family" }
                );
                context.Users.Add(addUserDto2.ToEntity());
                context.SaveChanges();
            }

            _userService = new UserService(new DataContext(_options));
        }
        [Test,Order(1)]
        public void GetUsers_ShouldReturnAllUsers()
        {
            // Act
            var result = _userService.GetUsers().ToList();

            // Assert
            ClassicAssert.AreEqual(2, result.Count);
            ClassicAssert.AreEqual("John", result[0].FirstName);
            ClassicAssert.AreEqual("Jane", result[1].FirstName);
        }

        [Test, Order(2)]
        public void GetUser_ValidId_ShouldReturnUser()
        {
            // Act
            var result = _userService.GetUser(1);

            // Assert
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual("John", result.FirstName);
        }

        [Test]
        public void GetUser_InvalidId_ShouldThrowException()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _userService.GetUser(999)); // ID не существует
        }

        [Test]
        public async Task AddUser_ValidDto_ShouldAddUser()
        {
            // Arrange
            var addUserDto = new AddUserDto
            (
                "John",
                "A.",
                "Doe",
                30,
                true,
                2,
                1,
                1,
                new Position { Title = "Developer" },
                new Gender { Title = "Male" },
                new Family { Title = "Doe Family" }
            );

            // Act
            await _userService.AddUser(addUserDto);

            // Assert
            using (var context = new DataContext(_options))
            {
                var user = context.Users.LastOrDefault(u => u.FirstName == "John" && u.LastName == "Doe");
                ClassicAssert.NotNull(user);
            }
        }

        [Test, Order(3)]
        public async Task EditUser_ValidId_ShouldEditUser()
        {
            // Arrange
            var editUserDto = new EditUserDto
            (
                "Jane",
                "A.",
                "Doe",
                30,
                true,
                2,
                1,
                1,
                new Position { Title = "Developer" },
                new Gender { Title = "Male" },
                new Family { Title = "Doe Family" }
            );

            // Act
            await _userService.EditUser(1, editUserDto);

            // Assert
            using (var context = new DataContext(_options))
            {
                var user = context.Users.Find(1);
                ClassicAssert.AreEqual("Jane", user.FirstName);
                ClassicAssert.AreEqual("Doe", user.LastName);
            }
        }

        [Test]
        public async Task EditUser_InvalidId_ShouldThrowException()
        {
            // Arrange
            var editUserDto = new EditUserDto
            (
                "Jane",
                "A.",
                "Doe",
                30,
                true,
                2,
                1,
                1,
                new Position { Title = "Developer" },
                new Gender { Title = "Male" },
                new Family { Title = "Doe Family" }
            );

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _userService.EditUser(999, editUserDto));
        }

        [Test]
        public async Task DeleteUser_ValidId_ShouldRemoveUser()
        {
            // Act
            await _userService.DeleteUser(1);

            // Assert
            using (var context = new DataContext(_options))
            {
                var user = context.Users.Find(1);
                ClassicAssert.Null(user);
            }
        }

        [Test]
        public async Task DeleteUser_InvalidId_ShouldThrowException()
        {
            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _userService.DeleteUser(999));
        }
    }
}
