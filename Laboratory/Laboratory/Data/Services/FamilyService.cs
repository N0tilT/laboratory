using Laboratoty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.Data.Services
{
    public class FamilyService
    {
        private DataContext _context;
        public FamilyService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Family> GetFamilies() => _context.Families;
        public Family GetFamily(int id) => _context.Families.Find(id) ?? throw new Exception();
    }
}
