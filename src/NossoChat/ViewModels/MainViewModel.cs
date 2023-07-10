using NossoChat.Models;
using NossoChat.Pages;
using NossoChat.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace NossoChat.ViewModels;

public class MainViewModel : BaseViewModel
{
    private string _username;

    private string _password;

    public MainViewModel()
        => EnterCommand = new Command(async () => await OnEnterCommand());

    public ICommand EnterCommand { get; set; }

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
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
