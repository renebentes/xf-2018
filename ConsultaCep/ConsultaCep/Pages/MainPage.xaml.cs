using ConsultaCep.Model;
using ConsultaCep.Services;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ConsultaCep.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly ICepService _service;

        public MainPage()
        {
            InitializeComponent();

            _service = new HttpClientService();

            Buscar.Clicked += OnBuscarClicked;
        }

        private async void OnBuscarClicked(object sender, System.EventArgs e)
        {
            string cep = Cep.Text.Trim();

            if (Validate(cep))
            {
                if (await _service.ObterEndereco(cep) is Endereco endereco)
                {
                    Resultado.Text = $"Endereço: {endereco.Localidade} - {endereco.Uf}, {endereco.Logradouro} - {endereco.Bairro}";
                }
                else
                {
                    await DisplayAlert("ERRO", $"O CEP {cep} não foi encontrado", "Ok").ConfigureAwait(false);
                }
            }
            else
            {
                await DisplayAlert("ERRO", "O CEP informado é inválido", "Ok").ConfigureAwait(false);
            }
        }

        private bool Validate(string cep) => Regex.IsMatch(cep ?? "", "[0-9]{8}");
    }
}
