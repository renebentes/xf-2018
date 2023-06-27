namespace NossoChat.ViewModels;

public class MainViewModel : BaseViewModel
{
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
}
