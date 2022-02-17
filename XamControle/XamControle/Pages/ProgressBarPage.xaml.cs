using System;

using Xamarin.Forms;

namespace XamControle.Pages;

public partial class ProgressBarPage : ContentPage
{
    public ProgressBarPage() => InitializeComponent();

    private void Modificar(object sender, EventArgs e)
    {
        Bar1.Progress = 1;
        Bar2.ProgressTo(1, 5000, Easing.Linear);
        Bar3.ProgressTo(1, 5000, Easing.SpringIn);
    }
}
