using BibliotecaAPI.Data;
using BibliotecaAPI.Dto;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Services
{
    public class RentalService : IRentalService
    {
        private readonly AppDbContext _context;

        public RentalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RentDto>> GetAllAsync()
        {
            return await _context.Rentals
                .Include(r => r.Book)
                .Include(r => r.User)
                .Select(r => new RentDto
                {
                    Id = r.Id,
                    BookId = r.BookId,
                    UserId = r.UserId,
                    BookTitle = r.Book.Title,
                    UserName = r.User.Name,
                    RentalDate = r.RentalDate,
                    ReturnDate = r.ReturnDate
                })
                .ToListAsync();
        }

        public async Task<RentDto?> GetByIdAsync(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Book)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental is null) return null;

            return new RentDto
            {
                Id = rental.Id,
                BookId = rental.BookId,
                UserId = rental.UserId,
                BookTitle = rental.Book.Title,
                UserName = rental.User.Name,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate
            };
        }

        public async Task<RentDto> RentBookAsync(ToRentDto dto)
        {
            var book = await _context.Books.FindAsync(dto.BookId);
            if (book is null || !book.isRented)
                throw new Exception("Book not available for rent.");

            book.isRented = true;

            var rental = new Rental
            {
                BookId = dto.BookId,
                UserId = dto.UserId,
                RentalDate = DateTime.UtcNow
            };

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            await _context.Entry(rental).Reference(r => r.Book).LoadAsync();
            await _context.Entry(rental).Reference(r => r.User).LoadAsync();

            return new RentDto
            {
                Id = rental.Id,
                BookId = rental.BookId,
                UserId = rental.UserId,
                BookTitle = rental.Book.Title,
                UserName = rental.User.Name,
                RentalDate = rental.RentalDate
            };
        }

        public async Task<RentDto?> ReturnBookAsync(int rentalId)
        {
            var rental = await _context.Rentals
                .Include(r => r.Book)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == rentalId);

            if (rental is null) return null;
            if (rental.ReturnDate is not null)
                throw new Exception("Book already returned.");

            rental.ReturnDate = DateTime.UtcNow;
            rental.Book.isRented = false;

            await _context.SaveChangesAsync();

            return new RentDto
            {
                Id = rental.Id,
                BookId = rental.BookId,
                UserId = rental.UserId,
                BookTitle = rental.Book.Title,
                UserName = rental.User.Name,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental is null) return false;

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
