
using System;
using Xamarin.Forms;

namespace TiposPaginas.Navigation
{
    public partial class ModalPage : ContentPage
    {
        public ModalPage() => InitializeComponent();

        private void FecharModal(object sender, EventArgs e) => Navigation.PopModalAsync();
    }
}
