using NossoChat.Models;
using NossoChat.Pages;
using NossoChat.Services;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace NossoChat.ViewModels;

public class MainViewModel : BaseViewModel
{
    private string _password = string.Empty;
    private string _username = string.Empty;

    public ICommand EnterCommand
        => CommandFactory.Create(OnEnterCommand);

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    private async Task OnEnterCommand()
    {
        var user = new User
        {
            Username = Username,
            Password = Password
        };

        var loggedUser = await DataService.GetUser(user);

        if (loggedUser.Id == 0)
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Nome de usuário ou senha inválidos", "Ok");
            return;
        }

        PreferenceService.SaveUser(loggedUser);

        Application.Current.MainPage = new NavigationPage(new ChatsPage());
    }
}
