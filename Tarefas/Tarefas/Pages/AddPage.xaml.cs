using System;
using Xamarin.Forms;

namespace Tarefas.Pages
{
    public partial class AddPage : ContentPage
    {
        private Label _lastTapped = new Label();

        public AddPage()
            => InitializeComponent();

        private void OnTapped(object sender, EventArgs e)
        {
            if (sender is not FlexLayout flexLayout) return;

            if (flexLayout.Children[1] is not Label label || label == _lastTapped) return;

            VisualStateManager.GoToState(_lastTapped, "Normal");
            VisualStateManager.GoToState(label, "Selected");
            _lastTapped = label;
        }
    }
}
