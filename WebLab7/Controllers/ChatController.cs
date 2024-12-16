using Microsoft.AspNetCore.Mvc;
using WebLab7.Filters;
using WebLab7.Models;
using WebLab7.Services.Intefaces;

namespace WebLab7.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [HATEOASFilter]
    public class ChatController(IChatService chatService) : Controller
    {
        [HttpPost]
        public async Task<ChatDto> CreateChat([FromBody] ChatDto dto)
        {
            return await chatService.CreateChat(dto);
        }

        [HttpGet]
        public async Task<ChatDto> GetChat([FromQuery] long id)
        {
            return await chatService.GetChat(id);
        }

        [HttpPut]
        public async Task<ChatDto> UpdateChat([FromBody] ChatDto dto)
        {
            return await chatService.UpdateChat(dto);
        }

        [HttpDelete]
        public async Task<ChatDto> DeleteChat([FromQuery] long id)
        {
            return await chatService.DeleteChat(id);
        }
    }
}
