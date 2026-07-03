namespace BibliotecaAPI.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public int BookCount { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
