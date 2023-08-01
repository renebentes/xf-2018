using NossoChat.Models;
using NossoChat.Pages;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace NossoChat.ViewModels;

public class ChatsViewModel : BaseViewModel
{
    public ChatsViewModel()
        => LoadDataCommand.Execute(null);

    public ICommand AddCommand => new Command(async () => await AddChat());

    public ObservableCollection<Chat> Chats { get; private set; } = new ObservableCollection<Chat>();

    public ICommand GetChatMessagesCommand => new Command<Chat>(async (chat) => await GetChatMessages(chat));

    public ICommand LoadDataCommand => new Command(async () => await LoadDataAsync());

    public ICommand SortCommand => new Command(SortData);

    private Task AddChat()
        => Application.Current.MainPage.Navigation.PushAsync(new AddChatPage());

    private async Task GetChatMessages(Chat chat)
    {
        if (chat is null)
            return;

        await Application.Current.MainPage.Navigation.PushAsync(new ChatPage(chat));
    }

    private async Task LoadDataAsync()
    {
        var chats = await DataService.GetChats();

        Chats.Clear();

        chats.ForEach(chat => Chats.Add(chat));
    }

    private void SortData()
    {
        var ordered = Chats.OrderBy(c => c.Name).ToList();
        Chats.Clear();
        ordered.ForEach(chat => Chats.Add(chat));
    }
}
