
using Laboratoty.Data.DTOs;
using Laboratoty.Data.Entities;
using Laboratoty.Data.Mapper;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Labotory.Test
{
    public class UserMapperTests
    {
        [Test]
        public void ToEntity_AddUserDto_ShouldMapProperties()
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
            User user = addUserDto.ToEntity();

            // Assert
            ClassicAssert.AreEqual(addUserDto.FirstName, user.FirstName);
            ClassicAssert.AreEqual(addUserDto.MiddleName, user.MiddleName);
            ClassicAssert.AreEqual(addUserDto.LastName, user.LastName);
            ClassicAssert.AreEqual(addUserDto.HasChildren, user.HasChildren);
            ClassicAssert.AreEqual(addUserDto.Age, user.Age);
            ClassicAssert.AreEqual(addUserDto.FamilyId, user.FamilyId);
            ClassicAssert.AreEqual(addUserDto.Family, user.Family);
            ClassicAssert.AreEqual(addUserDto.PositionId, user.PositionId);
            ClassicAssert.AreEqual(addUserDto.Position, user.Position);
            ClassicAssert.AreEqual(addUserDto.GenderId, user.GenderId);
            ClassicAssert.AreEqual(addUserDto.Gender, user.Gender);
        }

        [Test]
        public void ToEntity_EditUserDto_ShouldMapProperties()
        {
            // Arrange
            var editUserDto = new EditUserDto
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
            int userId = 1;

            // Act
            User user = editUserDto.ToEntity(userId);

            // Assert
            ClassicAssert.AreEqual(userId, user.Id);
            ClassicAssert.AreEqual(editUserDto.FirstName, user.FirstName);
            ClassicAssert.AreEqual(editUserDto.MiddleName, user.MiddleName);
            ClassicAssert.AreEqual(editUserDto.LastName, user.LastName);
            ClassicAssert.AreEqual(editUserDto.HasChildren, user.HasChildren);
            ClassicAssert.AreEqual(editUserDto.Age, user.Age);
            ClassicAssert.AreEqual(editUserDto.FamilyId, user.FamilyId);
            ClassicAssert.AreEqual(editUserDto.Family, user.Family);
            ClassicAssert.AreEqual(editUserDto.PositionId, user.PositionId);
            ClassicAssert.AreEqual(editUserDto.Position, user.Position);
            ClassicAssert.AreEqual(editUserDto.GenderId, user.GenderId);
            ClassicAssert.AreEqual(editUserDto.Gender, user.Gender);
        }

        [Test]
        public void ToUserDTO_ShouldMapProperties()
        {
            // Arrange
            var user = new User
            {
                FirstName = "John",
                MiddleName = "A.",
                LastName = "Doe",
                Age = 30,
                HasChildren = true,
                PositionId = 2,
                GenderId = 1,
                FamilyId = 3
            };

            // Act
            UserDto userDto = user.ToUserDTO();

            // Assert
            ClassicAssert.AreEqual(user.FirstName, userDto.FirstName);
            ClassicAssert.AreEqual(user.MiddleName ?? "", userDto.MiddleName);
            ClassicAssert.AreEqual(user.LastName ?? "", userDto.LastName);
            ClassicAssert.AreEqual(user.Age, userDto.Age);
            ClassicAssert.AreEqual(user.HasChildren, userDto.HasChildren);
            ClassicAssert.AreEqual(user.PositionId, userDto.PositionId);
            ClassicAssert.AreEqual(user.GenderId, userDto.GenderId);
            ClassicAssert.AreEqual(user.FamilyId, userDto.FamilyId);
        }

        [Test]
        public void ToUserMaxDTO_ShouldMapProperties()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FirstName = "Jane",
                MiddleName = "B.",
                LastName = "Doe",
                Age = 28,
                HasChildren = false,
                Position = null,
                Gender = null,
                Family = null
            };

            var position = new Position { Title = "Default Position" };
            var gender = new Gender { Title = "Default Gender" };
            var family = new Family { Title = "Default Family" };

            // Act
            UserMaxDto userMaxDto = user.ToUserMaxDTO(position, gender, family);

            // Assert
            ClassicAssert.AreEqual(user.Id, userMaxDto.Id);
            ClassicAssert.AreEqual(user.FirstName, userMaxDto.FirstName);
            ClassicAssert.AreEqual(user.MiddleName ?? "", userMaxDto.MiddleName);
            ClassicAssert.AreEqual(user.LastName ?? "", userMaxDto.LastName);
            ClassicAssert.AreEqual(user.Age, userMaxDto.Age);
            ClassicAssert.AreEqual(user.HasChildren, userMaxDto.HasChildren);
            ClassicAssert.AreEqual("Default Position", userMaxDto.Position);
            ClassicAssert.AreEqual("Default Gender", userMaxDto.Gender);
            ClassicAssert.AreEqual("Default Family", userMaxDto.Family);
        }
    }
}