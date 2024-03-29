using System;
using Xamarin.Forms;

namespace XamStyle.Pages
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
            => InitializeComponent();

        private void GoToPage(object sender, EventArgs e)
        {
            if (sender is not Button button) return;

            var type = $"XamStyle.Pages.{button.Text.Replace(" ", "")}Page";
            Detail = new NavigationPage((ContentPage)Activator.CreateInstance(Type.GetType(type) ?? throw new InvalidOperationException()));
            IsPresented = false;
        }
    }
}
