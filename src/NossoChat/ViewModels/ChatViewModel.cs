using NossoChat.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace NossoChat.ViewModels;

public class ChatViewModel : BaseViewModel
{
    private Chat _chat = default!;

    public ChatViewModel(Chat chat)
        => Chat = chat;

    public Chat Chat
    {
        get => _chat;
        set
        {
            if (_chat == value)
                return;

            _chat = value;
            OnPropertyChanged();
            LoadMessagesCommand.Execute(value);
        }
    }

    public ICommand LoadMessagesCommand
        => new Command<Chat>(async (chat) => await LoadMessages(chat));

    public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();

    private async Task LoadMessages(Chat chat)
    {
        Messages.Clear();

        var messages = await DataService.GetChatMessages(chat.Id);
        messages.ForEach(message => Messages.Add(message));
    }
}
