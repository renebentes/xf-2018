using CommunityToolkit.Mvvm.Input;
using NossoChat.Models;
using NossoChat.Pages;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace NossoChat.ViewModels;

public partial class ChatsViewModel : BaseViewModel
{
    public ObservableCollection<Chat> Chats { get; private set; } = new ObservableCollection<Chat>();

    [RelayCommand]
    private Task AddChat()
        => Navigation.PushAsync(new AddChatPage());

    [RelayCommand]
    private async Task GetChatMessages(Chat chat)
        => await Navigation.PushAsync(new ChatPage(chat));

    [RelayCommand]
    private async Task LoadDataAsync()
        => await ExecuteAsync(async () =>
        {
            var chats = await DataService.GetChats();

            Chats.Clear();

            chats.ForEach(chat => Chats.Add(chat));
        });

    [RelayCommand]
    private void SortData()
    {
        var ordered = Chats.OrderBy(c => c.Name).ToList();
        Chats.Clear();
        ordered.ForEach(chat => Chats.Add(chat));
    }
}
