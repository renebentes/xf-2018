namespace NossoChat.Models;

public class Message
{
    public string Content { get; set; }

    public int Id { get; set; }

    public User User { get; set; }
}
