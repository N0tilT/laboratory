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

        public static User ToEntity(this AddUserDto game)
        {
            return new User()
            {
                FirstName = game.FirstName,
                MiddleName = game.MiddleName,
                LastName = game.LastName,
                HasChildren = game.HasChildren,
                Age = game.Age,
                FamilyId = game.FamilyId,
                PositionId = game.PositionId,
                GenderId = game.GenderId,
            };
        }

        public static User ToEntity(this EditUserDto game)
        {
            return new User()
            {
                FirstName = game.FirstName,
                MiddleName = game.MiddleName,
                LastName = game.LastName,
                HasChildren = game.HasChildren,
                Age = game.Age,
                FamilyId = game.FamilyId,
                PositionId = game.PositionId,
                GenderId = game.GenderId,
            };
        }

        public static UserDto ToUserDTO(this User game)
        {
            return new UserDto(
                game.FirstName,
                game.MiddleName??"",
                game.LastName??"",
                game.Age,
                game.HasChildren,
                game.PositionId,
                game.GenderId,
                game.FamilyId
            );
        }

        public static UserMaxDto ToUserMaxDTO(this User game)
        {
            return new UserMaxDto(
                game.Id,
                game.FirstName,
                game.MiddleName ?? "",
                game.LastName ?? "",
                game.Age,
                game.HasChildren,
                game.Position?.Title ?? "",
                game.Gender?.Title ?? "",
                game.Family?.Title ?? ""
            );
        }
    }
}
