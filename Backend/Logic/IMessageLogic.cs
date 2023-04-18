using Backend.Model;
using System.Collections.Generic;

namespace Backend.Logic
{
    public interface IMessageLogic
    {
        void Add(Message newMessage);
        List<Message> GetAll();
    }
}
