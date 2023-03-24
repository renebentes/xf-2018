using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vagas.Models;
using Xamarin.Forms;

namespace Vagas.Pages
{
    public partial class MyPage : ContentPage
    {
        private IReadOnlyCollection<Vaga>? vagas;

        public MyPage()
            => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await LoadAsync();
        }

        private void FillData()
        {
            collection.ItemsSource = vagas;
            totalVagas.Text = vagas?.Count switch
            {
                0 => "Nenhuma vaga encontrada!",
                1 => "1 vaga encontrada!",
                _ => $"{vagas?.Count} vagas encontradas!"
            };
        }

        private async Task LoadAsync()
        {
            vagas = await App.Database.GetAllAsync();
            FillData();
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            if (sender is Label label && label.GestureRecognizers[0] is TapGestureRecognizer tapGesture)
            {
                var vaga = (Vaga)tapGesture.CommandParameter;
                await App.Database.DeleteAsync(vaga);
            }

            await LoadAsync();
        }
    }
}
