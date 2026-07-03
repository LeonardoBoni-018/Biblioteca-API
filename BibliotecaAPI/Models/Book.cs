namespace BibliotecaAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public string Genre { get; set; }
        public bool isRented { get; set; } = false;
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
