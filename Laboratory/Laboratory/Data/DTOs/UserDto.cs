using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.Data.DTOs
{
    public record class UserDto
    (
        string FirstName,
        string MiddleName,
        string LastName,
        int Age,
        bool HasChildren,
        int PositionId,
        int GenderId,
        int FamilyId
    );
}
