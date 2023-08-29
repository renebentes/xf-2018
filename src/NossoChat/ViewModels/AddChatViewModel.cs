using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NossoChat.Models;
using Xamarin.Forms;

namespace NossoChat.ViewModels;

public partial class AddChatViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _name = string.Empty;

    [RelayCommand]
    private async Task Save()
    {
        var chat = new Chat
        {
            Name = Name,
        };

        if (await DataService.AddChat(chat))
        {
            _ = await Application.Current.MainPage.Navigation.PopAsync();
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível adicionar o chat", "Ok");
        }
    }
}
