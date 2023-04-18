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
    public class MessageController : Controller
    {
        IMessageLogic logic;
        IHubContext<SignalRHub> hub;

        public MessageController(IMessageLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public List<Message> ReadAll()
        {
            return this.logic.GetAll();
        }

        [HttpPost]
        public void Create([FromBody] Message message)
        {
            this.logic.Create(message);
            this.hub.Clients.All.SendAsync("MessageCreated", message);
        }
    }
}
