using System.Collections.Generic;
using Xamarin.Forms;
using XamControle.Models;

namespace XamControle.Pages;

public partial class ListViewPage : ContentPage
{
    public ListViewPage() => InitializeComponent();

    public IList<Pessoa> Pessoas { get; } = new List<Pessoa>
    {
        new Pessoa { Nome = "José", Idade = 20 },
        new Pessoa { Nome = "Maria", Idade = 23 },
        new Pessoa { Nome = "Felipe", Idade = 25 },
        new Pessoa { Nome = "João", Idade = 30 }
    };
}
