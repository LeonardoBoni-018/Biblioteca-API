namespace BibliotecaAPI.Dto
{
    public class RentDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
