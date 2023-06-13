using Xamarin.Forms;

namespace XamControle.Pages;

public partial class SliderStepperPage : ContentPage
{
    public SliderStepperPage() => InitializeComponent();

    private void OnIncreaseValue(object sender, ValueChangedEventArgs e)
    {
        StepperResultado.Text = e.NewValue.ToString();
    }

    private void OnValueChanged(object sender, ValueChangedEventArgs e) => SliderResultado.Text = e.NewValue.ToString();
}
