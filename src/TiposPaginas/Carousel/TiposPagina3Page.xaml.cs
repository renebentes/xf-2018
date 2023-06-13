
using System;
using TiposPaginas.Tabbed;
using Xamarin.Forms;

namespace TiposPaginas.Carousel
{
    public partial class TiposPagina3Page : ContentPage
    {
        public TiposPagina3Page() => InitializeComponent();

        private void MudarPagina(object sender, EventArgs e) => App.Current.MainPage = new AbasPage();
    }
}
