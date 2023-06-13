using System.IO;
using Xamarin.Forms;

namespace XamControle.Pages;

public partial class ImagePage : ContentPage
{
    public ImagePage() => InitializeComponent();

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var imagePath = "usb.jpg";

        if (Device.RuntimePlatform == Device.UWP)
        {
            imagePath = Path.Combine("Assets", imagePath);
        }

        var image = new Image {
            Source = imagePath
        };

        container.Children.Add(image);
    }
}
