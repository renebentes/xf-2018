using Mimica.Models;
using Mimica.ViewModels;
using Xamarin.Forms;

namespace Mimica.Pages
{
    public partial class GamePage : ContentPage
    {
        public GamePage(Player player)
        {
            InitializeComponent();

            BindingContext = new GameViewModel(player);
        }
    }
}
