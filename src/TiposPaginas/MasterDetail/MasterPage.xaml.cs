
using System;
using TiposPaginas.Navigation;
using Xamarin.Forms;

namespace TiposPaginas.MasterDetail
{
    [Obsolete]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage() => InitializeComponent();

        private void MudarPagina1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina1Page());

            if (Device.Idiom == TargetIdiom.Phone)
            {
                IsPresented = false;
            }
        }

        private void MudarPagina2(object sender, EventArgs e)
        {
            Detail = new Pagina2Page();

            if (Device.Idiom == TargetIdiom.Phone)
            {
                IsPresented = false;
            }
        }

        private void MudarConteudo(object sender, EventArgs e)
        {
            Detail = new ConteudoPage();

            if (Device.Idiom == TargetIdiom.Phone)
            {
                IsPresented = false;
            }
        }
    }
}
