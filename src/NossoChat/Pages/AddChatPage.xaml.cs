using NossoChat.ViewModels;
using Xamarin.Forms;

namespace NossoChat.Pages;

public partial class AddChatPage : ContentPage
{
    public AddChatPage()
    {
        InitializeComponent();

        BindingContext = new AddChatViewModel();
    }
}
