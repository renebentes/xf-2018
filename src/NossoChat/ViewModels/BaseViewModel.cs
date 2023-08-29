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

    [RelayCommand]
    private Task NavigateTo(Page? page)
        => page is not null ? Navigation.PushAsync(page) : Task.CompletedTask;
}
