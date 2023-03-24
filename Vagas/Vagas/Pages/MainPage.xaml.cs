using System;
using Vagas.Models;
using Xamarin.Forms;

namespace Vagas.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
            => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vagas = await App.Database.GetAllAsync();
            collection.ItemsSource = vagas;
            totalVagas.Text = vagas.Count switch
            {
                0 => "Nenhuma vaga encontrada!",
                1 => "1 vaga encontrada!",
                _ => $"{vagas.Count} vagas encontradas!"
            };
        }

        private void OnGoToCreatePage(object sender, EventArgs e)
            => Navigation.PushAsync(new CreatePage());
    }
}
