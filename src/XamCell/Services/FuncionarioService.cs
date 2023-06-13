using System.Collections.Generic;
using XamCell.Models;

namespace XamCell.Services
{
    public class FuncionarioService
    {
        private readonly IList<Funcionario> _funcionarios;

        public FuncionarioService()
            => _funcionarios = new List<Funcionario>
            {
                new Funcionario { Nome = "José", Cargo = "Presidente", Foto="https://api.lorem.space/image/face?w=50&h=50&hash=2D297A22" },
                new Funcionario { Nome = "Maria", Cargo = "Gerente de Vendas", Foto="https://api.lorem.space/image/face?w=50&h=50&hash=500B67FB" },
                new Funcionario { Nome = "Elaine", Cargo = "Gerente de Marketing", Foto="https://api.lorem.space/image/face?w=50&h=50&hash=A89D0DE6" },
                new Funcionario { Nome = "Felipe", Cargo = "Entregador", Foto="https://api.lorem.space/image/face?w=50&h=50&hash=225E6693" },
                new Funcionario { Nome = "João", Cargo = "Vendedor", Foto="https://api.lorem.space/image/face?w=50&h=50&hash=9D9539E7" }
            };

        public IEnumerable<Funcionario> GetAll()
            => _funcionarios;
    }
}
