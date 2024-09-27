using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = "Some_user";
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public int Age { get; set; } = 0;
        public bool HasChildren { get; set; }

        public int FamilyId { get; set; }
        public Family? Family { get; set; }

        public int PositionId { get; set; }
        public Position? Position { get; set; }

        public int GenderId { get; set; }
        public Gender? Gender{ get; set; }

    }
}
