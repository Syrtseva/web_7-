namespace WebLab7.Models
{
    public class UserDto
    {
        public UserDto(long id, string name, string secondName, string? bio, string username, string email, string password)
        {
            Id = id;
            Name = name;
            SecondName = secondName;
            Bio = bio;
            Username = username;
            Email = email;
            Password = password;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string? Bio { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
