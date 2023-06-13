using System;
using Xamarin.Forms;

namespace XamControle.Pages;

public partial class SwitchPage : ContentPage
{
    public SwitchPage() => InitializeComponent();

    private void OnToggled(object sender, ToggledEventArgs e) => Resultado.Text = $"{DateTime.Now:HH:mm} - {e.Value}";
}
