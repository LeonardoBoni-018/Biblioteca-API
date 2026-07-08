using BibliotecaAPI.Dto;

namespace BibliotecaAPI.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<CreateUserDto> CreateAsync(CreateUserDto dto);
        Task<UserDto?> UpdateAsync(int id, CreateUserDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
