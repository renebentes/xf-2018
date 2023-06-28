using NossoChat.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NossoChat.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    protected BaseViewModel()
        => DataService = new DataService();

    public event PropertyChangedEventHandler PropertyChanged = null!;

    protected DataService DataService { get; }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
