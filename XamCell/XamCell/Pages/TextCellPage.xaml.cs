using System.Collections.Generic;
using Xamarin.Forms;
using XamCell.Models;

namespace XamCell.Pages
{
    public partial class TextCellPage : ContentPage
    {
        public TextCellPage()
        {
            InitializeComponent();

            var funcionarios = new List<Funcionario>
            {
                new Funcionario { Nome = "José", Cargo = "Presidente" },
                new Funcionario { Nome = "Maria", Cargo = "Gerente de Vendas" },
                new Funcionario { Nome = "Elaine", Cargo = "Gerente de Marketing" },
                new Funcionario { Nome = "Felipe", Cargo = "Entregador" },
                new Funcionario { Nome = "João", Cargo = "Vendedor" }
            };

            listView.ItemsSource = funcionarios;
        }
    }
}
