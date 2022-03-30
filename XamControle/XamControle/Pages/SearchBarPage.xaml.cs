using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamControle.Pages;

public partial class SearchBarPage : ContentPage
{
    private readonly IList<string> _empresas = new List<string> { "Microsoft", "Oracle", "Google", "IBM", "Uber", "99Taxi" };

    public SearchBarPage()
    {
        InitializeComponent();
        Fill(_empresas);
    }

    private void Fill(IList<string> empresas)
    {
        Resultado.Children.Clear();
        foreach (var empresa in empresas)
        {
            Resultado.Children.Add(new Label { Text = empresa });
        }
    }

    private void OnSearch(object sender, EventArgs e)
    {
        if (sender is SearchBar searchBar)
        {
            var resultado = _empresas.Where(empresa => empresa.Contains(searchBar.Text)).ToList();
            Fill(resultado);
        }
    }
}
