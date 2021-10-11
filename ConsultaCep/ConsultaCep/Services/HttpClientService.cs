using ConsultaCep.Helpers;
using ConsultaCep.Model;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsultaCep.Services
{
    public class HttpClientService : ICepService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = Constants.ViaCepBaseUrl;

        public HttpClientService() => _httpClient = new HttpClient();

        public async Task<Endereco> ObterEndereco(string cep)
        {
            var endereco = new Endereco();
            string[] segments = new string[] { Constants.ViaCepBaseUrl, cep, "json" };
            string url = string.Join("/", segments);
            var uri = new Uri(url);

            try
            {
                HttpResponseMessage reponse = await _httpClient.GetAsync(uri);

                if (reponse.IsSuccessStatusCode)
                {
                    string content = await reponse.Content.ReadAsStringAsync();
                    endereco = JsonSerializer.Deserialize<Endereco>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return endereco;
        }
    }
}
