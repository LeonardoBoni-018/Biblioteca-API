namespace BibliotecaAPI.Dto
{
    public class UpdateRentDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
