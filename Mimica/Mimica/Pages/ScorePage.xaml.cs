using Mimica.ViewModels;
using Xamarin.Forms;

namespace Mimica.Pages
{
    public partial class ScorePage : ContentPage
    {
        public ScorePage()
        {
            InitializeComponent();
            BindingContext = new ScoreViewModel();
        }
    }
}
