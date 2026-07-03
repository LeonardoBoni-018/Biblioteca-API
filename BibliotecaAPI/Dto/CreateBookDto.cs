namespace BibliotecaAPI.Dto
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
    }
}
