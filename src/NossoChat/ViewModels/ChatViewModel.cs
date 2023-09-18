using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NossoChat.Models;
using NossoChat.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace NossoChat.ViewModels;

public partial class ChatViewModel : BaseViewModel
{
    [ObservableProperty]
    private Chat _chat = default!;

    [ObservableProperty]
    private string _newMessage = string.Empty;

    private Message _selectedMessage = default!;

    public ChatViewModel(Chat chat)
        => Chat = chat;

    public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();

    public Message SelectedMessage
    {
        get => _selectedMessage;
        set
        {
            _ = SetProperty(ref _selectedMessage, value);
            DeleteMessageCommand.NotifyCanExecuteChanged();
        }
    }

    private bool CanDeleteMessage => SelectedMessage is not null;

    [RelayCommand(CanExecute = nameof(CanDeleteMessage))]
    private async Task DeleteMessage(Message message)
        => await ExecuteAsync(async () =>
        {
            var isRemoved = await DataService.RemoveMessage(message);
            if (!isRemoved)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível remover a mensagem", "Ok");
            }

            await LoadMessages(Chat);
        });

    [RelayCommand]
    private async Task LoadMessages(Chat chat)
    {
        Messages.Clear();

        IList<Message> messages = await DataService.GetChatMessages(chat.Id);
        messages.ForEach(message => Messages.Add(message));
    }

    [RelayCommand]
    private async Task SendMessage()
    {
        var user = SettingsService.GetUser();
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
