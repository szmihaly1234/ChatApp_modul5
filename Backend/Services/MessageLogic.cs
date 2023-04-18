using Backend.Logic;
using Backend.Model;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Services
{
    public class MessageLogic : IMessageLogic
    {
        List<Message> messages;
        public MessageLogic()
        {
            messages = new List<Message>();
            messages.Add(new Message("PH", "PH"));
        }

        public void Create(Message newMessage)
        {
            messages.Add(newMessage);
        }

        public List<Message> GetAll()
        {
            return messages;
        }
    }
}
