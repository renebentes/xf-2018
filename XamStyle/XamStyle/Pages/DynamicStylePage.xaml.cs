using System;
using Xamarin.Forms;

namespace XamStyle.Pages
{
    public partial class DynamicStylePage : ContentPage
    {
        public DynamicStylePage()
            => InitializeComponent();

        private void OnChangeColor(object sender, EventArgs e)
            => Resources["RedColor"] = Color.FromHex("#ffb3b3");
    }
}

