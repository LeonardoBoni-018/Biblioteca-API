namespace BibliotecaAPI.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearPublished { get; set; }
        public string Genre { get; set; } = string.Empty;
        public bool isRented { get; set; } = false;
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
    }
}
