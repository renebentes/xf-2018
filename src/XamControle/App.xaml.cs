using Xamarin.Forms;
using XamControle.Pages;

namespace XamControle;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }

    protected override void OnResume()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnStart()
    {
    }
}
