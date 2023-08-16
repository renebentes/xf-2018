using NossoChat.Models;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace NossoChat.ViewModels;

public class AddChatViewModel : BaseViewModel
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public ICommand SaveCommand
        => CommandFactory.Create(async () => await Save());

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
