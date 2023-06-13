using Xamarin.Forms;
using XamStyle.Pages;

namespace XamStyle
{
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
    }
}
