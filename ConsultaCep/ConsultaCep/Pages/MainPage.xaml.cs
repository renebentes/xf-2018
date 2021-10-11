using ConsultaCep.Services;
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
            Model.Endereco endereco = await _service.ObterEndereco(cep);
            Resultado.Text = $"Endereço: {endereco.Localidade} - {endereco.Uf}, {endereco.Logradouro} - {endereco.Bairro}";
        }
    }
}
