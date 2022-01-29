using Xamarin.Forms;

namespace XamPages.Pages
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage() => InitializeComponent();

        private void GoToProfilePage(object sender, System.EventArgs e) => Detail = new NavigationPage(new ProfilePage());
    }
}
