using Xamarin.Forms;
using XamCell.Services;

namespace XamCell.Pages
{
    public partial class ViewCellPage : ContentPage
    {
        public ViewCellPage()
        {
            InitializeComponent();

            var service = new FuncionarioService();

            listView.ItemsSource = service.GetAll();
        }
    }
}
