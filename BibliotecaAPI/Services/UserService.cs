using BibliotecaAPI.Data;
using BibliotecaAPI.Dto;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return await _context.Users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
            }).ToListAsync();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<CreateUserDto> CreateAsync(CreateUserDto createUserDto)
        {

            var user = new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                PasswordHash = createUserDto.Password,
                Role = createUserDto.Role
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new CreateUserDto
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.PasswordHash,
                Role = user.Role
            };
        }

        public async Task<UserDto?> UpdateAsync(int id, CreateUserDto createUserDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null) return null;

            await _context.Users.Where(u => u.Id == id).ExecuteUpdateAsync(u => u
                 .SetProperty(u => u.Name, createUserDto.Name)
                 .SetProperty(u => u.Email, createUserDto.Email)
                 .SetProperty(u => u.PasswordHash, createUserDto.Password)
                 .SetProperty(u => u.Role, createUserDto.Role));
            return new UserDto
            {
                Id = user.Id,
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Role = createUserDto.Role
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
