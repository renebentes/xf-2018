using Xamarin.Forms;

namespace XamPages.Pages
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage() => InitializeComponent();

        private void GoToProfilePage(object sender, System.EventArgs e) => Navigation.PushAsync(new ProfilePage());
    }
}
