using TiposPaginas.Carousel;
using Xamarin.Forms;

namespace TiposPaginas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TiposPagina3Page();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
