
using TiposPaginas.Navigation;
using Xamarin.Forms;

namespace TiposPaginas.Carousel
{
    public partial class TiposPagina3Page : ContentPage
    {
        public TiposPagina3Page() => InitializeComponent();

        private void MudarPagina(object sender, System.EventArgs e) => App.Current.MainPage = new Pagina1Page();
    }
}
