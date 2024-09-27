using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.Data.DTOs
{
    public record class UserMaxDto
    (
        int Id,
        string FirstName,
        string MiddleName,
        string LastName,
        int Age,
        bool HasChildren,
        string Position,
        string Gender,
        string Family
    );
}
