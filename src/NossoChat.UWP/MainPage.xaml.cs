namespace NossoChat.UWP;

public sealed partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();

        LoadApplication(new NossoChat.App());
    }
}
