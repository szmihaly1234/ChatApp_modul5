namespace ChatApp_backend.Model
{
    public class ChatObject
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public ChatObject(string name, string message)
        {
            Name = name;
            Message = message;
            Date = DateTime.Now.ToString();
        }
        public override string ToString()
        {
            return Date + " " + Name + " " + Message + '\n';
        }
    }
}
