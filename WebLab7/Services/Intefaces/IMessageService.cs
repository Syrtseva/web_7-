using WebLab7.Models;

namespace WebLab7.Services.Intefaces
{
    public interface IMessageService
    {
        Task<MessageDto> Send(MessageDto messageDto);
        Task<MessageDto> GetMessage(long id);
        Task<MessageDto> UpdateMessage(MessageDto messageDto);
        Task<MessageDto> DeleteMessage(long id);
    }
}
