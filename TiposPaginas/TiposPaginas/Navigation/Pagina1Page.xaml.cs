
using System;
using Xamarin.Forms;

namespace TiposPaginas.Navigation
{
    public partial class Pagina1Page : ContentPage
    {
        public Pagina1Page() => InitializeComponent();

        private void MudarPagina(object sender, EventArgs e) => Navigation.PushAsync(new Pagina2Page());

        private void ChamarModal(object sender, EventArgs e) => Navigation.PushModalAsync(new ModalPage());
    }
}
