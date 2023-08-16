using NossoChat.Models;
using NossoChat.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
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
        => CommandFactory.Create(async (message) => await DeleteMessage(message), (Message message) => message is not null);

    public ICommand LoadMessagesCommand
        => CommandFactory.Create<Chat>(async (chat) => await LoadMessages(chat));

    public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();

    public string NewMessage
    {
        get => _newMessage;
        set => SetProperty(ref _newMessage, value);
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
        => CommandFactory.Create(async () => await SendMessage());

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

        var isSaved = await DataService.AddMessage(newMessage);
        if (isSaved)
        {
            NewMessage = string.Empty;
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível enviar a mensagem", "Ok");
        }

        await LoadMessages(Chat);
    }
}
