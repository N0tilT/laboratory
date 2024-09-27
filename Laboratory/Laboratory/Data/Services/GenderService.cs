using Laboratoty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.Data.Services
{
    public class GenderService
    {
        private DataContext _context;
        public GenderService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Gender> GetGenders() => _context.Genders;
        public Gender GetGender(int id) => _context.Genders.Find(id) ?? throw new Exception();
    }
}
