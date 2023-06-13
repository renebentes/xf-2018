using SQLite;

namespace Vagas.Models
{
    public class Vaga
    {
        public string? Cidade { get; set; }

        public string? Descricao { get; set; }

        public string? Email { get; set; }

        public string? Empresa { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public short Quantidade { get; set; }

        public double Salario { get; set; }

        public string? Telefone { get; set; }

        public string? TipoContratacao { get; set; }
    }
}
