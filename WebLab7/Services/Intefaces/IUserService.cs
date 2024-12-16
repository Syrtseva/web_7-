using WebLab7.Models;

namespace WebLab7.Services.Intefaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserDto userDto);
        Task<UserDto> GetUser(long id);
        Task<UserDto> UpdateUser(UserDto user);
        Task<UserDto> DeleteUser(long id);
    }
}
