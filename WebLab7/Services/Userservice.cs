using WebLab7.Models;
using WebLab7.Services.Intefaces;

namespace WebLab7.Services
{
    public class UserService : IUserService
    {
        private readonly List<UserDto> _users = new()
        {
            new UserDto(1, "Frank", "Gholt", "Developer", "@frankgholt", "frankgholt@email.com", "password"),
            new UserDto(2, "Jane", "Doe", "Designer", "@janedoe", "jane.doe@email.com", "password123")
        };

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            _users.Add(userDto);
            return await Task.FromResult(userDto);
        }

        public async Task<UserDto> DeleteUser(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                return await Task.FromResult(user);
            }
            throw new KeyNotFoundException($"User with ID {id} not found.");
        }

        public async Task<UserDto> GetUser(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                return await Task.FromResult(user);
            throw new KeyNotFoundException($"User with ID {id} not found.");
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            var user = _users.FirstOrDefault(u => u.Id == userDto.Id);
            if (user != null)
            {
                user.Name = userDto.Name;
                user.SecondName = userDto.SecondName;
                user.Bio = userDto.Bio;
                user.Username = userDto.Username;
                user.Email = userDto.Email;
                user.Password = userDto.Password;
                return await Task.FromResult(user);
            }
            throw new KeyNotFoundException($"User with ID {userDto.Id} not found.");
        }
    }
}
