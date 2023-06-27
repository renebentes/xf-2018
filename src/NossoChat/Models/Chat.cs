namespace NossoChat.Models;

public class Chat
{
    public int Id { get; set; }

    public IList<Message> Messages { get; set; }

    public string Name { get; set; }
}
