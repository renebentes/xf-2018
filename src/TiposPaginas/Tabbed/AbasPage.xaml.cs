
using TiposPaginas.Navigation;
using Xamarin.Forms;

namespace TiposPaginas.Tabbed
{
    public partial class AbasPage : TabbedPage
    {
        public AbasPage()
        {
            InitializeComponent();

            Children.Add(new NavigationPage(new Pagina1Page()) { Title = "Item 3" });
        }
    }
}
