using ChatApp_backend.Model;

namespace ChatApp_backend.Logic
{
    public interface IChatObjectLogic
    {
        void AddMessage(ChatObject newMessage);
        string ReadAll();
    }
}
