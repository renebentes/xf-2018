using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Vagas.Models;
using Xamarin.Forms;

namespace Vagas.Pages
{
    public partial class CreatePage : ContentPage
    {
        private readonly Vaga _vaga;

        public CreatePage(Vaga? vaga = null)
        {
            InitializeComponent();

            _vaga = vaga ?? new Vaga();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            name.Text = _vaga.Nome;
            company.Text = _vaga.Empresa;
            quantity.Text = _vaga.Quantidade.ToString();
            salary.Text = _vaga.Salario.ToString();
            city.Text = _vaga.Cidade;
            description.Text = _vaga.Descricao;
            tipoContratacao.IsToggled = _vaga.TipoContratacao == "PJ";
            telefone.Text = _vaga.Telefone;
            email.Text = _vaga.Email;
        }

        private async void OnSave(object sender, EventArgs e)
            => await SaveAsync();

        private async Task SaveAsync()
        {
            try
            {
                _vaga.Nome = name.Text;
                _vaga.Empresa = company.Text;
                _vaga.Quantidade = short.Parse(quantity.Text);
                _vaga.Salario = double.Parse(salary.Text);
                _vaga.Cidade = city.Text;
                _vaga.Descricao = description.Text;
                _vaga.TipoContratacao = tipoContratacao.IsToggled ? "PJ" : "CLT";
                _vaga.Telefone = telefone.Text;
                _vaga.Email = email.Text;

                if (_vaga.Id == 0)
                {
                    await App.Database.CreateAsync(_vaga);
                }
                else
                {
                    await App.Database.UpdateAsync(_vaga);
                }

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
