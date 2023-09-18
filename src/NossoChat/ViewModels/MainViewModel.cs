using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NossoChat.Models;
using NossoChat.Pages;
using NossoChat.Services;
using Xamarin.Forms;

namespace NossoChat.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private string _username = string.Empty;

    [RelayCommand]
    private async Task SignIn()
        => await ExecuteAsync(async () =>
        {
            var user = new User
            {
                Username = Username,
                Password = Password
            };

            var loggedUser = await DataService.GetUser(user);

            if (loggedUser?.Id == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Nome de usuário ou senha inválidos", "Ok");
                return;
            }

            SettingsService.SaveUser(loggedUser);

            await Navigation.PushAsync(new ChatsPage());
        });
}
