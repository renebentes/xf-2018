using System;
using System.Linq;
using Tarefas.Enums;
using Xamarin.Forms;

namespace Tarefas.Pages
{
    public partial class AddPage : ContentPage
    {
        private Label _lastTapped = new Label();
        private Priority _priority;

        public AddPage()
            => InitializeComponent();

        private void GetPriority(BoxView boxView)
        {
            var priority = boxView
                            .StyleClass
                            .LastOrDefault(style => style.Contains("Priority"))?
                            .Replace("Priority", string.Empty) ?? "Low";

            _priority = (Priority)Enum.Parse(typeof(Priority), priority);
        }

        private void OnTapped(object sender, EventArgs e)
        {
            if (sender is not FlexLayout flexLayout)
            {
                return;
            }

            if (flexLayout.Children[0] is not BoxView boxView)
            {
                return;
            }

            if (flexLayout.Children[1] is not Label label || label == _lastTapped)
            {
                return;
            }

            GetPriority(boxView);

            VisualStateManager.GoToState(_lastTapped, "Normal");
            VisualStateManager.GoToState(label, "Selected");
            _lastTapped = label;
        }
    }
}
