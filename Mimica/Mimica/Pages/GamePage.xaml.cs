using Mimica.ViewModels;
using Xamarin.Forms;

namespace Mimica.Pages
{
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();

            BindingContext = new GameViewModel();
        }
    }
}
