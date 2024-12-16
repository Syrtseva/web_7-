using WebLab7.Models;
using WebLab7.Services.Intefaces;

namespace WebLab7.Services
{
    public class MessageService : IMessageService
    {
        private readonly List<MessageDto> _messages = new()
        {
            new MessageDto( 1,  "Hello, everyone!",  1, 1, DateTime.UtcNow),
            new MessageDto(2, "Welcome to the chat!", 1, 2, DateTime.UtcNow)
        };

        public async Task<MessageDto> Send(MessageDto messageDto)
        {
            _messages.Add(messageDto);
            return await Task.FromResult(messageDto);
        }

        public async Task<MessageDto> GetMessage(long id)
        {
            var message = _messages.FirstOrDefault(m => m.Id == id);
            if (message != null)
                return await Task.FromResult(message);
            throw new KeyNotFoundException($"Message with ID {id} not found.");
        }

        public async Task<MessageDto> UpdateMessage(MessageDto messageDto)
        {
            var message = _messages.FirstOrDefault(m => m.Id == messageDto.Id);
            if (message != null)
            {
                message.Message = messageDto.Message;
                message.ChatId = messageDto.ChatId;
                message.CreatedBy = messageDto.CreatedBy;
                message.CreatedAt = messageDto.CreatedAt;
                return await Task.FromResult(message);
            }
            throw new KeyNotFoundException($"Message with ID {messageDto.Id} not found.");
        }

        public async Task<MessageDto> DeleteMessage(long id)
        {
            var message = _messages.FirstOrDefault(m => m.Id == id);
            if (message != null)
            {
                _messages.Remove(message);
                return await Task.FromResult(message);
            }
            throw new KeyNotFoundException($"Message with ID {id} not found.");
        }
    }
}
