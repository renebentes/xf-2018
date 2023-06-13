using System;

using Xamarin.Forms;

namespace XamControle.Pages;

public partial class WebViewPage : ContentPage
{
    public WebViewPage() => InitializeComponent();

    private void GoBack(object sender, EventArgs e)
    {
        if (navegador.CanGoBack)
        {
            navegador.GoBack();
        }
    }

    private void GoNext(object sender, EventArgs e)
    {
        if (navegador.CanGoForward)
        {
            navegador.GoForward();
        }
    }

    private void GoTo(object sender, EventArgs e) => navegador.Source = endereco.Text;

    private void OnNavigated(object sender, WebNavigatedEventArgs e) => status.Text = "Carregado.";

    private void OnNavigating(object sender, WebNavigatingEventArgs e) => status.Text = "Carregando...";
}
