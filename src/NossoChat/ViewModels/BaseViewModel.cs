using NossoChat.Services;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace NossoChat.ViewModels;

public abstract class BaseViewModel : ObservableObject
{
    protected BaseViewModel()
        => DataService = new DataService();

    public ICommand NavigateCommand
        => CommandFactory.Create<Page>(page => NavigateTo(page));

    protected DataService DataService { get; }

    protected INavigation Navigation
        => Application.Current.MainPage.Navigation;

    private Task NavigateTo(Page? page)
        => page is not null ? Navigation.PushAsync(page) : Task.CompletedTask;
}
