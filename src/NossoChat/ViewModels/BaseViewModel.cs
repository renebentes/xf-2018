using NossoChat.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace NossoChat.ViewModels;

public abstract class BaseViewModel : ObservableObject
{
    protected BaseViewModel()
        => DataService = new DataService();

    protected DataService DataService { get; }
}
