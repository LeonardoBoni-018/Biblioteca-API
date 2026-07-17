namespace BibliotecaAPI.Dto
{
    public class CreateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Nacionality { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
