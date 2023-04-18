using ChatApp_backend.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        IChatLogic chatLogic;
        public ChatController(IChatLogic chatLogic)
        {
            this.chatLogic = chatLogic;
        }
        [HttpGet]
        public string ReadAll()
        {
            return chatLogic.ReadAllChat();
        }
        
    }
}
