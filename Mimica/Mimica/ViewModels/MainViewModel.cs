using Mimica.Data;
using Mimica.Models;
using Mimica.Pages;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mimica.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
            => StartGameCommand = new Command(OnStartGame);

        public event PropertyChangedEventHandler PropertyChanged;

        public Game Game { get; set; } = null!;

        public string[] Levels => Enum.GetNames(typeof(Level));

        public ICommand StartGameCommand { get; set; }

        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void OnStartGame()
        {
            DataStore.Game = Game;
            DataStore.CurrentRound = 1;
            Application.Current.MainPage = new GamePage();
        }
    }
}
