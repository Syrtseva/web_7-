using Microsoft.AspNetCore.Mvc;
using WebLab7.Filters;
using WebLab7.Models;
using WebLab7.Services.Intefaces;

namespace WebLab7.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [HATEOASFilter]
    public class MessageController(IMessageService messageService) : Controller
    {
        [HttpPost]
        public async Task<MessageDto> Send([FromBody] MessageDto dto)
        {
            return await messageService.Send(dto);
        }

        [HttpGet]
        public async Task<MessageDto> GetMessage([FromQuery] long id)
        {
            return await messageService.GetMessage(id);
        }

        [HttpPut]
        public async Task<MessageDto> UpdateMessage([FromBody] MessageDto dto)
        {
            return await messageService.UpdateMessage(dto);
        }

        [HttpDelete]
        public async Task<MessageDto> DeleteMessage([FromQuery] long id)
        {
            return await messageService.DeleteMessage(id);
        }
    }
}
