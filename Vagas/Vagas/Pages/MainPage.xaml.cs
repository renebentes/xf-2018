using Xamarin.Forms;

namespace Vagas.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
            => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collection.ItemsSource = await App.Database.GetAllAsync();
        }
    }
}
