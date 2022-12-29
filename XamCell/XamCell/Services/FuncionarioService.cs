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
                new Funcionario { Nome = "José", Cargo = "Presidente" },
                new Funcionario { Nome = "Maria", Cargo = "Gerente de Vendas" },
                new Funcionario { Nome = "Elaine", Cargo = "Gerente de Marketing" },
                new Funcionario { Nome = "Felipe", Cargo = "Entregador" },
                new Funcionario { Nome = "João", Cargo = "Vendedor" }
            };

        public IEnumerable<Funcionario> GetAll()
            => _funcionarios;
    }
}
