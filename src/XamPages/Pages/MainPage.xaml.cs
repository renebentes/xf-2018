using Xamarin.Forms;

namespace XamPages.Pages
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage() => InitializeComponent();

        private void GoToAboutPage(object sender, System.EventArgs e) => Detail = new NavigationPage(new AboutPage());

        private void GoToProfilePage(object sender, System.EventArgs e) => Detail = new NavigationPage(new ProfilePage());
    }
}
