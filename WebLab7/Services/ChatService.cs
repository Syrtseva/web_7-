using WebLab7.Models;
using WebLab7.Services.Intefaces;

namespace WebLab7.Services
{
    public class ChatService : IChatService
    {
        private readonly List<ChatDto> _chats = new()
        {
            new ChatDto(1, "General", "A general chat room", new List<UserDto>
            {
                new UserDto(1, "Frank", "Gholt", "Developer", "@frankgholt", "frankgholt@email.com", "password"),
                new UserDto(2, "Jane", "Doe", "Designer", "@janedoe", "jane.doe@email.com", "password123")
            })
        };

        public async Task<ChatDto> CreateChat(ChatDto chatDto)
        {
            _chats.Add(chatDto);
            return await Task.FromResult(chatDto);
        }

        public async Task<ChatDto> DeleteChat(long id)
        {
            var chat = _chats.FirstOrDefault(c => c.Id == id);
            if (chat != null)
            {
                _chats.Remove(chat);
                return await Task.FromResult(chat);
            }
            throw new KeyNotFoundException($"Chat with ID {id} not found.");
        }

        public async Task<ChatDto> GetChat(long id)
        {
            var chat = _chats.FirstOrDefault(c => c.Id == id);
            if (chat != null)
                return await Task.FromResult(chat);
            throw new KeyNotFoundException($"Chat with ID {id} not found.");
        }

        public async Task<ChatDto> UpdateChat(ChatDto chatDto)
        {
            var chat = _chats.FirstOrDefault(c => c.Id == chatDto.Id);
            if (chat != null)
            {
                chat.Name = chatDto.Name;
                chat.Description = chatDto.Description;
                chat.Members = chatDto.Members;
                return await Task.FromResult(chat);
            }
            throw new KeyNotFoundException($"Chat with ID {chatDto.Id} not found.");
        }
    }
}
