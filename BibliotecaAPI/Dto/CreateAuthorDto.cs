namespace BibliotecaAPI.Dto
{
    public class CreateAuthorDto
    {
        public string Name { get; set; }
        public string Nacionality { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
