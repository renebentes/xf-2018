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
            listButtonView.ItemsSource = service.GetAll();
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
            if (sender is MenuItem menu)
            {
                Show(menu.CommandParameter);
            }
            else if (sender is Button button)
            {
                Show(button.CommandParameter);
            }

            void Show(object commandParameter)
            {
                if (commandParameter is Funcionario funcionario)
                {
                    _ = DisplayAlert($"Título: {funcionario.Nome}", $"Mensagem: {funcionario.Cargo}", "Ok");
                }
            }
        }
    }
}
