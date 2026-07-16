using BibliotecaAPI.Dto;

namespace BibliotecaAPI.Services
{
    public interface IRentalService
    {
        Task<List<RentDto>> GetAllAsync();
        Task<RentDto?> GetByIdAsync(int id);
        Task<RentDto> RentBookAsync(ToRentDto dto);
        Task<RentDto?> ReturnBookAsync(int rentalId);
        Task<bool> DeleteAsync(int id);
    }
}
