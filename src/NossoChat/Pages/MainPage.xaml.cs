using NossoChat.ViewModels;
using Xamarin.Forms;

namespace NossoChat.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = new MainViewModel();
    }
}
