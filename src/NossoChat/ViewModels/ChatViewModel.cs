using NossoChat.Models;
using NossoChat.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace NossoChat.ViewModels;

public class ChatViewModel : BaseViewModel
{
    private Chat _chat = default!;
    private string _newMessage = string.Empty;
    private Message _selectedMessage = default!;

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

    public ICommand DeleteMessageCommand
        => new Command<Message>(async (message) => await DeleteMessage(message), (Message message) => message is not null);

    public ICommand LoadMessagesCommand
        => new Command<Chat>(async (chat) => await LoadMessages(chat));

    public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();

    public string NewMessage
    {
        get => _newMessage;
        set
        {
            if (_newMessage != value)
            {
                _newMessage = value;
                OnPropertyChanged();
            }
        }
    }

    public Message SelectedMessage
    {
        get => _selectedMessage;
        set
        {
            if (_selectedMessage == value)
                return;

            _selectedMessage = value;
            OnPropertyChanged();
            ((Command)DeleteMessageCommand).ChangeCanExecute();
        }
    }

    public ICommand SendMessageCommand
        => new Command(async () => await SendMessage());

    private async Task DeleteMessage(Message message)
    {
        var isRemoved = await DataService.RemoveMessage(message);
        if (!isRemoved)
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível remover a mensagem", "Ok");
        }

        await LoadMessages(Chat);
    }

    private async Task LoadMessages(Chat chat)
    {
        Messages.Clear();

        var messages = await DataService.GetChatMessages(chat.Id);
        messages.ForEach(message => Messages.Add(message));
    }

    private async Task SendMessage()
    {
        var user = PreferenceService.GetUser();
        var newMessage = new Message
        {
            ChatId = Chat.Id,
            Content = NewMessage,
            UserId = user.Id
        };

        _ = await DataService.AddMessage(newMessage);
        await LoadMessages(Chat);
    }
}
