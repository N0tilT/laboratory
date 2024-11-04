using Laboratoty.Data.DTOs;
using Laboratoty.Data.Entities;
using Laboratoty.Data.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.Data.Services
{
    public class UserService
    {
        public DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDto> GetUsers() => _context.Users.ToList().Count() > 0 ? _context.Users.ToList().Select(x => x.ToUserDTO()) : [];
        public IEnumerable<UserMaxDto> GetUsersFull()
        {
            if (_context.Users != null)
                if (_context.Users.Count() > 0)
                    return _context.Users.ToList().Select(x => x.ToUserMaxDTO(
                        _context.Positions.ToList().Find(y => y.Id == x.PositionId),
                        _context.Genders.ToList().Find(y => y.Id == x.GenderId), 
                        _context.Families.ToList().Find(y => y.Id == x.FamilyId)
                        ));
            return [];
        }

        public User GetUser(int id) => _context.Users.Find(id) ?? throw new Exception();
        public async Task AddUser(AddUserDto addUserDto) {
            var entity = addUserDto.ToEntity();
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task EditUser(int id, EditUserDto editUserDto)
        {
            var existingUser = await _context.Users.FindAsync(id) ?? throw new Exception();

            _context.Entry(existingUser)
                     .CurrentValues
                     .SetValues(editUserDto.ToEntity(id));
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new Exception();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
