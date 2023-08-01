using NossoChat.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace NossoChat.ViewModels;

public class AddChatViewModel : BaseViewModel
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public ICommand SaveCommand
        => new Command(async () => await Save());

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
