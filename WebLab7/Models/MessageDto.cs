namespace WebLab7.Models
{
    public class MessageDto
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public long ChatId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public MessageDto(long id, string message, long chatId, long createdBy, DateTime createdAt)
        {
            Id = id;
            Message = message;
            ChatId = chatId;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
        }

    }
}
