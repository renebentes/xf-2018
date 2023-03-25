using Mimica.ViewModels;
using Xamarin.Forms;

namespace Mimica.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}
