namespace WebLab7.Models
{
    public class ChatDto
    {
        public ChatDto(long id, string name, string description, List<UserDto> members)
        {
            Id = id;
            Name = name;
            Description = description;
            Members = members;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserDto> Members { get; set; } = [];
    }
}
