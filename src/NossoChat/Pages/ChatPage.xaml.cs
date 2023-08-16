using NossoChat.Models;
using NossoChat.ViewModels;
using Xamarin.Forms;

namespace NossoChat.Pages;

public partial class ChatPage : ContentPage
{
    public ChatPage(Chat chat)
    {
        InitializeComponent();

        BindingContext = new ChatViewModel(chat);
    }
}
