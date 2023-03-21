using ConsultaCep.Model;
using System.Threading.Tasks;

namespace ConsultaCep.Services
{
    public interface ICepService
    {
        Task<Endereco> ObterEndereco(string cep);
    }
}
