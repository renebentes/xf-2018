using Mimica.Data;
using Mimica.Models;
using Mimica.Pages;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Mimica.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Level selectedLevel;
        private string selectedLevelName;

        public MainViewModel()
        {
            StartGameCommand = new Command(OnStartGame);
            Game = new Game
            {
                PlayerOne = new Player(),
                PlayerTwo = new Player()
            };

            Enum.GetNames(typeof(Level)).ForEach((name) => Levels.Add(name));
        }

        public Game Game { get; set; }

        public ObservableCollection<string> Levels { get; } = new ObservableCollection<string>();

        public string SelectedLevelName
        {
            get => selectedLevelName;
            set
            {
                if (selectedLevelName != value)
                {
                    selectedLevelName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SelectedLevel));
                }
            }
        }

        public Level SelectedLevel
            => string.IsNullOrEmpty(selectedLevelName)
                ? Level.Random
                : (Level)Enum.Parse(typeof(Level), selectedLevelName, true);

        public ICommand StartGameCommand { get; set; }

        private void OnStartGame()
        {
            DataStore.Game = Game;
            DataStore.CurrentRound = 1;
            DataStore.Game.Level = SelectedLevel;
            Application.Current.MainPage = new GamePage(Game.PlayerOne);
        }
    }
}
