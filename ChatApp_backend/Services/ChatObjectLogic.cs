using ChatApp_backend.Logic;
using ChatApp_backend.Model;

namespace ChatApp_backend.Services
{
    public class ChatObjectLogic : IChatObjectLogic
    {
        List<ChatObject> chatObjects;
        public string Chat { get; set; }
        public ChatObjectLogic(List<ChatObject> chatObjects)
        {
            this.chatObjects = chatObjects;
            this.Chat = "";
        }
        public void AddMessage(ChatObject newMessage)
        {
            chatObjects.Add(newMessage);
        }

        public string ReadAll()
        {
            foreach (ChatObject chatObject in chatObjects)
            {
                Chat += chatObject.ToString();
            }
            return Chat;
        }
    }
}
