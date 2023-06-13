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
        private string errorMessage;
        private string selectedLevelName;

        public MainViewModel()
        {
            StartGameCommand = new Command(OnStartGame);
            Game = new Game
            {
                PlayerOne = new Player(),
                PlayerTwo = new Player(),
                WordTimeInSeconds = 120,
                Matches = 7
            };

            Enum.GetNames(typeof(Level)).ForEach((name) => Levels.Add(name));
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public Game Game { get; set; }

        public ObservableCollection<string> Levels { get; } = new ObservableCollection<string>();

        public Level SelectedLevel
            => string.IsNullOrEmpty(selectedLevelName)
                ? Level.Random
                : (Level)Enum.Parse(typeof(Level), selectedLevelName, true);

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

        public ICommand StartGameCommand { get; set; }

        private void OnStartGame()
        {
            if (Validate())
            {
                DataStore.Game = Game;
                DataStore.CurrentRound = 1;
                DataStore.Game.Level = SelectedLevel;
                Application.Current.MainPage = new GamePage(Game.PlayerOne);
            }

            bool Validate()
            {
                var message = string.Empty;

                if (Game.WordTimeInSeconds < 10)
                    message += "O tempo mínimo para uma palavra é 10 segundos";

                if (Game.Matches < 1)
                    message += "\nIndique o número de rodadas maior que 1";

                if (string.IsNullOrEmpty(message)) return true;

                ErrorMessage = message;
                return false;
            }
        }
    }
}
