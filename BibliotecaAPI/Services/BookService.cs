using BibliotecaAPI.Data;
using BibliotecaAPI.Dto;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _context.Books.Select(b => new BookDto
            {
                Id = b.Id,
                Genre = b.Genre,
                Title = b.Title,
                YearPublished = b.YearPublished,
                isRented = b.isRented,
                AuthorId = b.AuthorId,
                AuthorName = b.Author.Name
            }).ToListAsync();

            if(books == null || books.Count == 0)
            {
                throw new Exception("No books found.");
            }
            return books;
        }

        public async Task<BookDto?> GetByIdAsync(int bookId ) {
            var book = await _context.Books.Include
                (b => b.Author).FirstOrDefaultAsync(b => b.Id == bookId);

            if(book == null)
            {
                return null;
            }

            return new BookDto
            {
                Id =book.Id,
                AuthorId=book.AuthorId,
                AuthorName=book.Author.Name,
                Genre = book.Genre,
                isRented=book.isRented,
                Title = book.Title,
                YearPublished = book.YearPublished
            };
        }

        public async Task<BookDto> CreateAsync(CreateBookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                YearPublished = bookDto.YearPublished,
                Genre = bookDto.Genre,
                AuthorId = bookDto.AuthorId,
                isRented = false
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                YearPublished = book.YearPublished,
                Genre = book.Genre,
                isRented = book.isRented,
                AuthorId = book.AuthorId,
                AuthorName = (await _context.Authors.FindAsync(book.AuthorId))?.Name ?? ""
            };
        }

        public async Task<BookDto?> UpdateAsync(int bookId, CreateBookDto bookDto) {
            var book = await _context.Books.Include
               (b => b.Author).FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                return null;
            }
            book.Title = bookDto.Title;
            book.YearPublished = bookDto.YearPublished;
            book.Genre = bookDto.Genre;
            book.AuthorId = bookDto.AuthorId;
            book.isRented = false;
            book.Author = await _context.Authors.FindAsync(bookDto.AuthorId);   

            await _context.SaveChangesAsync();
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                YearPublished = book.YearPublished,
                Genre = book.Genre,
                isRented = book.isRented,
                AuthorId = book.AuthorId,
                AuthorName = book.Author.Name
            };
        }

        public async Task<bool> DeleteAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                return false;
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
