using Laboratoty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.Data.Services
{
    public class PositionService
    {
        private DataContext _context;
        public PositionService(DataContext context) {
            _context = context;
        }

        public IEnumerable<Position> GetPositions() => _context.Positions;
        public Position GetPosition(int id) => _context.Positions.Find(id) ?? throw new Exception();
    }
}
