using Tarefas.Models;
using Xamarin.Forms;

namespace Tarefas.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
            => InitializeComponent();

        protected override void OnAppearing()
        {
            listView.ItemsSource = new TaskManager().ListAll();
        }

        private void OpenAddPage(object sender, System.EventArgs e)
            => Navigation.PushAsync(new AddPage());
    }
}
