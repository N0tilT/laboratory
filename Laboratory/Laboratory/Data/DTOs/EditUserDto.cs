using Laboratoty.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.Data.DTOs
{
    public record class EditUserDto(
        [Required][StringLength(256)] string FirstName,
        [StringLength(256)] string MiddleName,
        [StringLength(256)] string LastName,
        [Range(1,100)]int Age,
        bool HasChildren,
        [Required] int PositionId,
        int GenderId,
        int FamilyId,
        Position Position,
        Gender Gender,
        Family Family
        );
}
