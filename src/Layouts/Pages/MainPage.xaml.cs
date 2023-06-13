using Xamarin.Forms;

namespace Layouts.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => InitializeComponent();

        private void GoToStackPage(object sender, System.EventArgs e) => Navigation.PushAsync(new StackPage());

        private void GoToAbsolutePage(object sender, System.EventArgs e) => Navigation.PushAsync(new AbsolutePage());

        private void GoToRelativePage(object sender, System.EventArgs e) => Navigation.PushAsync(new RelativePage());

        private void GoToGridPage(object sender, System.EventArgs e) => Navigation.PushAsync(new GridPage());

        private void GoToScrollPage(object sender, System.EventArgs e) => Navigation.PushAsync(new ScrollPage());


    }
}
