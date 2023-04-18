using ChatApp_backend.Logic;
using ChatApp_backend.Model;

namespace ChatApp_backend.Services
{
    public class ChatLogic : IChatLogic
    {
        public string Chat { get; set; }

        public ChatLogic() 
        {
            Chat = "";
        }

        public void AddMessage(ChatObject chatObject)
        {
            Chat += chatObject.ToString();
        }

        public string ReadAllChat()
        {
            return Chat;
        }
    }
}
