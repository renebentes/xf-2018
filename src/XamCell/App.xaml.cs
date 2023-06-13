using Xamarin.Forms;
using XamCell.Pages;

namespace XamCell
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
