namespace BibliotecaAPI.Dto
{
    public class RentDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string UserName { get; set; }
        public DateOnly DateRented { get; set; }
        public DateOnly? DateReturned { get; set; }
    }
}
