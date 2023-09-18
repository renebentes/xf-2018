using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NossoChat.Services;
using Xamarin.Forms;

namespace NossoChat.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    protected BaseViewModel()
        => DataService = new DataService();

    protected DataService DataService { get; }

    protected INavigation Navigation
        => Application.Current.MainPage.Navigation;

    protected async Task ExecuteAsync(
        Func<Task> action)
    {
        try
        {
            await action?.Invoke();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    [RelayCommand]
    private Task NavigateTo(Page? page)
        => page is not null ? Navigation.PushAsync(page) : Task.CompletedTask;
}
