using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Vagas.Models;
using Xamarin.Forms;

namespace Vagas.Pages
{
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
            => InitializeComponent();

        private async void OnSave(object sender, System.EventArgs e)
            => await SaveAsync();

        private async Task SaveAsync()
        {
            try
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

                _ = await Navigation.PopAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
