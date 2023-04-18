using Backend.Model;
using System.Collections.Generic;

namespace Backend.Logic
{
    public interface IMessageLogic
    {
        void Create(Message newMessage);
        List<Message> GetAll();
    }
}
