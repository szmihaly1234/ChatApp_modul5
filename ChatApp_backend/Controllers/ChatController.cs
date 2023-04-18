using ChatApp_backend.Logic;
using ChatApp_backend.Model;
using ChatApp_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace ChatApp_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        IChatObjectLogic chatLogic;
        IHubContext<SignalRHub> hub;
        public ChatController(IChatObjectLogic chatLogic, IHubContext<SignalRHub> hub)
        {
            this.chatLogic = chatLogic;
            this.hub = hub;
        }
        [HttpGet]
        public string ReadAll()
        {
            return chatLogic.ReadAll();
        }
        [HttpPost]
        public void AddMessage([FromBody] ChatObject value)
        {
            chatLogic.AddMessage(value);
            this.hub.Clients.All.SendAsync("ChatCreated", value);

        }
        
    }
}
