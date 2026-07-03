using BibliotecaAPI.Data;
using BibliotecaAPI.Dto;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorDto>> GetAllAsync()
        {
            return await _context.Authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                Nationality = a.Nationality,
                BirthDate = a.BirthDate,
                BookCount = a.Books.Count
            }).ToListAsync();
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);

            if(author == null)
            {
                return null;
            }

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Nationality = author.Nationality,
                BookCount = author.Books.Count,
                BirthDate = author.BirthDate
            };
    }

        public async Task<AuthorDto> CreateAsync(CreateAuthorDto dto)
        {
            var author = new Author
            {
                Name = dto.Name,
                Nationality = dto.Nacionality,
                BirthDate = dto.BirthDate
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Nationality = author.Nationality,
                BirthDate = author.BirthDate,
                BookCount = author.Books.Count
            };
        }

        public async Task<AuthorDto> UpdateAsync(int id, CreateAuthorDto dto)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return null;
            }

            author.Name = dto.Name;
            author.Name = dto.Nacionality;
            author.BirthDate = dto.BirthDate;

            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Nationality = author.Nationality,
                BirthDate = author.BirthDate,
                BookCount = author.Books.Count
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author is null) return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
