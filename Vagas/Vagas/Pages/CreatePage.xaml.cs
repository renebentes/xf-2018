using Vagas.Models;
using Xamarin.Forms;

namespace Vagas.Pages
{
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
            => InitializeComponent();

        private async void OnSave(object sender, System.EventArgs e)
        {
            var vaga = new Vaga
            {
                Nome = name.Text,
                Empresa = company.Text,
                Quantidade = short.Parse(quantity.Text),
                Salario = double.Parse(salary.Text),
                Cidade = city.Text,
                Descricao = description.Text,
                TipoContratacao = tipoContratacao.IsToggled ? "PJ" : "CLT",
                Telefone = telefone.Text,
                Email = email.Text
            };

            await App.Database.CreateAsync(vaga);
        }
    }
}
