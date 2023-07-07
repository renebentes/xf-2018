using NossoChat.ViewModels;
using Xamarin.Forms;

namespace NossoChat.Pages;

public partial class ChatsPage : ContentPage
{
    public ChatsPage()
    {
        InitializeComponent();

        BindingContext = new ChatsViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((ChatsViewModel)BindingContext).LoadDataCommand.Execute(null);
    }
}
