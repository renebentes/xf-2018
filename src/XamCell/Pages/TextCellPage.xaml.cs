using Xamarin.Forms;
using XamCell.Services;

namespace XamCell.Pages
{
    public partial class TextCellPage : ContentPage
    {
        public TextCellPage()
        {
            InitializeComponent();

            var service = new FuncionarioService();

            listView.ItemsSource = service.GetAll();
        }
    }
}
