using Vagas.Models;
using Xamarin.Forms;

namespace Vagas.Pages
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Vaga vaga)
        {
            InitializeComponent();
            BindingContext = vaga;
        }
    }
}
