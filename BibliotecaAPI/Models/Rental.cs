namespace BibliotecaAPI.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateOnly RentalDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public Book Book { get; set; }
    }
}
