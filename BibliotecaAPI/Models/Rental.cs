using BibliotecaAPI.Models;

public class Rental
{
    public int Id { get; set; }
    public int UserId { get; set; }           
    public int BookId { get; set; }
    public DateTime RentalDate { get; set; } = DateTime.UtcNow;
    public DateTime? ReturnDate { get; set; }
    public User User { get; set; } = null!;  
    public Book Book { get; set; } = null!;
}