using Xamarin.Forms;

namespace XamControle.Pages;

public partial class DatePickerPage : ContentPage
{
    public DatePickerPage() => InitializeComponent();

    private void OnDateSelected(object sender, DateChangedEventArgs e) => Resultado.Text = $"{e.OldDate:d} > {e.NewDate:d}";
}
