using Xamarin.Forms;
using XamCell.Models;
using XamCell.Services;

namespace XamCell.Pages
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            var service = new FuncionarioService();

            listView.ItemsSource = service.GetAll();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Funcionario funcionario)
            {
                _ = Navigation.PushAsync(new EmployeeDetailPage(funcionario));
            }
        }

        private void OnVacationClicked(object sender, System.EventArgs e)
        {
            if (((MenuItem)sender).CommandParameter is Funcionario funcionario)
            {
                _ = DisplayAlert($"Título: {funcionario.Nome}", $"Mensagem: {funcionario.Cargo}", "Ok");
            }
        }
    }
}
