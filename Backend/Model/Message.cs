using System;

namespace Backend.Model
{
    public class Message
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public Message(string Sender,string Content) {
            this.Sender = Sender;
            this.Content = Content;
            Date = DateTime.Now.ToString();
        }
        public Message() { }
    }
}
