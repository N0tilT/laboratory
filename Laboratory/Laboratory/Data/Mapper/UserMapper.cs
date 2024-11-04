using Laboratoty.Data.DTOs;
using Laboratoty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty    .Data.Mapper
{
    public static class UserMapper
    {

        public static User ToEntity(this AddUserDto user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                HasChildren = user.HasChildren,
                Age = user.Age,
                FamilyId = user.FamilyId,
                Family = user.Family,
                PositionId = user.PositionId,
                Position  = user.Position,
                GenderId = user.GenderId,
                Gender = user.Gender,
            };
        }

        public static User ToEntity(this EditUserDto user,int id)
        {
            return new User()
            {
                Id = id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                HasChildren = user.HasChildren,
                Age = user.Age,
                FamilyId = user.FamilyId,
                Family = user.Family,
                PositionId = user.PositionId,
                Position = user.Position,
                GenderId = user.GenderId,
                Gender = user.Gender,
            };
        }

        public static UserDto ToUserDTO(this User user)
        {
            return new UserDto(
                user.FirstName,
                user.MiddleName??"",
                user.LastName??"",
                user.Age,
                user.HasChildren,
                user.PositionId,
                user.GenderId,
                user.FamilyId
            );
        }

        public static UserMaxDto ToUserMaxDTO(this User user, Position position,Gender gender,Family family)
        {
            return new UserMaxDto(
                user.Id,
                user.FirstName,
                user.MiddleName ?? "",
                user.LastName ?? "",
                user.Age,
                user.HasChildren,
                user.Position?.Title ?? position.Title,
                user.Gender?.Title ?? gender.Title,
                user.Family?.Title ?? family.Title
            );
        }
    }
}
