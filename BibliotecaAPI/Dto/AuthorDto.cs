namespace BibliotecaAPI.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Nationality { get; set; }
        public int BookCount { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
