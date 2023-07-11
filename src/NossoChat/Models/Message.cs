namespace NossoChat.Models;

public class Message
{
    public int ChatId { get; set; }

    public string Content { get; set; }

    public int Id { get; set; }

    public User User { get; set; }

    public int UserId { get; set; }
}
