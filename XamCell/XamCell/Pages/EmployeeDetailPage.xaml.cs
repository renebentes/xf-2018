using Xamarin.Forms;
using XamCell.Models;

namespace XamCell.Pages
{
    public partial class EmployeeDetailPage : ContentPage
    {
        public EmployeeDetailPage(Funcionario funcionario)
        {
            InitializeComponent();

            nome.Text = funcionario.Nome;
        }
    }
}
