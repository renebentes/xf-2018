using System;
using Xamarin.Forms;

namespace XamCell.Pages
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
            => InitializeComponent();

        private void GoToPage(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var type = $"XamCell.Pages.{button.Text.Replace(" ", "")}Page";
                Detail = new NavigationPage((ContentPage)Activator.CreateInstance(Type.GetType(type)));
                IsPresented = false;
            }
        }
    }
}
