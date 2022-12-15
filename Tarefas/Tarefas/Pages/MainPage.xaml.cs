using Xamarin.Forms;

namespace Tarefas.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
            => InitializeComponent();

        private void OpenAddPage(object sender, System.EventArgs e)
            => Navigation.PushAsync(new AddPage());
    }
}
