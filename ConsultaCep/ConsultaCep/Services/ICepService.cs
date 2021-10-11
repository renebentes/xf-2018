using System.Threading.Tasks;
using ConsultaCep.Model;

namespace ConsultaCep.Services
{
    public interface ICepService
    {
        Task<Endereco> ObterEndereco(string cep);
    }
}
