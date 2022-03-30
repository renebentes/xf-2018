using Xamarin.Forms;

namespace XamControle.Pages;

public partial class PickerPage : ContentPage
{
    public PickerPage() => InitializeComponent();

    private void OnSelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (sender is Picker picker)
        {
            Resultado.Text = picker.SelectedItem.ToString();
        }
    }
}
