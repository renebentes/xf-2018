using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NossoChat.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NossoChat.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    protected BaseViewModel()
        => DataService = new DataService();

    protected DataService DataService { get; }

    protected INavigation Navigation
        => Application.Current.MainPage.Navigation;

    protected Task DisplayAlertAsync(string title, string message, string actionButton)
        => MainThread.InvokeOnMainThreadAsync(async () => await Application.Current.MainPage.DisplayAlert(title, message, actionButton));

    protected async Task ExecuteAsync(Func<Task> action)
    {
        try
        {
            await action?.Invoke();
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", "Ocorreu um erro. Por favor, tente novamente!", "Ok");
            Debug.WriteLine(ex);
        }
    }

    [RelayCommand]
    private Task NavigateTo(Page? page)
        => page is not null ? Navigation.PushAsync(page) : Task.CompletedTask;
}
