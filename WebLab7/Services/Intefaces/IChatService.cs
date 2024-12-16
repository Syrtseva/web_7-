using WebLab7.Models;

namespace WebLab7.Services.Intefaces
{
    public interface IChatService
    {
        Task<ChatDto> CreateChat(ChatDto chatDto);
        Task<ChatDto> GetChat(long id);
        Task<ChatDto> UpdateChat(ChatDto chatDto);
        Task<ChatDto> DeleteChat(long id);
    }
}
