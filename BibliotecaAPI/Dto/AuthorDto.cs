namespace BibliotecaAPI.Dto
{
    public class AuthorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; } 
        public DateOnly BirthDate { get; set; }
    }
}
