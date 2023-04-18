using Backend.Logic;
using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Collections.Generic;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatController : Controller
    {
        IMessageLogic logic;
        IHubContext<SignalRHub> hub;

        public ChatController(IMessageLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Message> ReadAll()
        {
            return this.logic.GetAll();
        }

        [HttpPost]
        public void Create([FromBody] Message message)
        {
            this.logic.Add(message);
            this.hub.Clients.All.SendAsync("ChatCreated", message);
        }
    }
}
