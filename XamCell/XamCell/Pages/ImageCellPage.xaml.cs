using Xamarin.Forms;
using XamCell.Services;

namespace XamCell.Pages
{
    public partial class ImageCellPage : ContentPage
    {
        public ImageCellPage()
        {
            InitializeComponent();

            var service = new FuncionarioService();

            listView.ItemsSource = service.GetAll();
        }
    }
}
