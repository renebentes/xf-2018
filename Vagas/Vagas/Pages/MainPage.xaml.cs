using System;
using System.Collections.Generic;
using System.Linq;
using Vagas.Models;
using Xamarin.Forms;

namespace Vagas.Pages
{
    public partial class MainPage : ContentPage
    {
        private IReadOnlyCollection<Vaga>? vagas;

        public MainPage()
            => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            vagas = await App.Database.GetAllAsync();
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

        private async void OnGoToDetail(object sender, EventArgs e)
        {
            if (sender is Label label && label.GestureRecognizers[0] is TapGestureRecognizer tapGesture)
            {
                var vaga = (Vaga)tapGesture.CommandParameter;
                await Navigation.PushAsync(new DetailPage(vaga));
            }
        }

        private void OnSearch(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                collection.ItemsSource = vagas.Where(vaga => vaga.Nome == entry.Text);
            }
        }
    }
}
